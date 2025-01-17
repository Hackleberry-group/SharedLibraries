using HackleberryServices.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Security.Claims;

public class MultiAuthRequirement : IAuthorizationRequirement
{
    public string[] Roles { get; }

    public MultiAuthRequirement(string[] roles = null)
    {
        Roles = roles ?? Array.Empty<string>();
    }
}

public class MultiAuthHandler : AuthorizationHandler<MultiAuthRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _apiKeyHeader;
    private readonly string[] _validApiKeys;

    public MultiAuthHandler(
        IHttpContextAccessor httpContextAccessor,
        IOptions<ApiKeyOptions> apiKeyOptions)
    {
        _httpContextAccessor = httpContextAccessor;
        _apiKeyHeader = apiKeyOptions.Value.HeaderName;
        _validApiKeys = apiKeyOptions.Value.ValidKeys;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        MultiAuthRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            return Task.CompletedTask;
        }

        
        if (context.User.Identity?.IsAuthenticated == true)
        {
            if (requirement.Roles.Length == 0 || requirement.Roles.Any(role => context.User.IsInRole(role)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

        if (httpContext.Request.Headers.TryGetValue(_apiKeyHeader, out var apiKeyValue))
        {
            var providedApiKey = apiKeyValue.ToString();
            if (!string.IsNullOrWhiteSpace(providedApiKey) &&
                _validApiKeys.Contains(providedApiKey, StringComparer.Ordinal))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "ApiKeyUser"),
                    new Claim(ClaimTypes.AuthenticationMethod, "ApiKey")
                };

                var identity = new ClaimsIdentity(claims, "ApiKey");
                context.User.AddIdentity(identity);

                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}

public class ApiKeyOptions
{
    private string[] _validKeys = Array.Empty<string>();

    public string HeaderName { get; set; } = "X-API-Key";
    public string[] ValidKeys
    {
        get => _validKeys;
        set => _validKeys = value?
            .Where(key => !string.IsNullOrWhiteSpace(key))
            .ToArray() ?? Array.Empty<string>();
    }
}

public class MultiAuthAttribute : AuthorizeAttribute
{
    public MultiAuthAttribute(string multiAuthPolicy)
    {
        Policy = multiAuthPolicy;
    }
}

public static class MultiAuthExtensions
{
    public static IServiceCollection AddMultiAuth(
        this IServiceCollection services,
        Action<ApiKeyOptions> configureApiKeys)
    {
        services.Configure(configureApiKeys);
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MultiAuth", policy =>
                policy.Requirements.Add(new MultiAuthRequirement()));

            var defaultRoles = new[] { ClaimsHelper.Roles.Admin, ClaimsHelper.Roles.Student, ClaimsHelper.Roles.Teacher};
            foreach (var role in defaultRoles)
            {
                options.AddPolicy($"MultiAuth_{role}", policy =>
                    policy.Requirements.Add(new MultiAuthRequirement(new[] { role })));
            }

            options.AddPolicy(ClaimsHelper.Policies.RequireAdminRole, policy =>
                policy.Requirements.Add(new MultiAuthRequirement(new[] { ClaimsHelper.Roles.Admin })));

            options.AddPolicy(ClaimsHelper.Policies.RequireTeacherRole, policy =>
                policy.Requirements.Add(new MultiAuthRequirement(new[] { ClaimsHelper.Roles.Admin, ClaimsHelper.Roles.Teacher })));

            options.AddPolicy(ClaimsHelper.Policies.RequireStudentRole, policy =>
            policy.Requirements.Add(new MultiAuthRequirement(new[] { ClaimsHelper.Roles.Admin, ClaimsHelper.Roles.Student })));
        });

        services.AddScoped<IAuthorizationHandler, MultiAuthHandler>();

        return services;
    }
}