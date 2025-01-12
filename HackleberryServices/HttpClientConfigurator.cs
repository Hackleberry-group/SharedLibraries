using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace HackleberryServices.HttpClientConfiguration;

public static class HttpClientConfigurator
{
    /// <summary>
    /// Adds an HttpClient with retry, circuit breaker, and timeout policies.
    /// </summary>
    /// <param name="services">The service collection to add the HttpClient to.</param>
    /// <param name="clientName">The name of the HttpClient.</param>
    /// <param name="baseAddress">The base address of the API.</param>
    /// <param name="retryCount">The base address of the API.</param>
    /// <param name="circuitBreaker">Whether to use a circuit breaker policy.</param>
    /// <param name="timeout">Optional timeout duration in seconds (defaults to 30)</param>
    public static void AddConfiguredHttpClient(
        IServiceCollection services,
        string clientName,
        string baseAddress,
        int retryCount,
        bool circuitBreaker,
        int timeout = 30)
    {
        if (circuitBreaker == true)
        {
            services.AddHttpClient(clientName, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(timeout);
            })
            .AddPolicyHandler((provider, _) => GetRetryPolicy(provider, retryCount))
            .AddPolicyHandler(GetTimeoutPolicy(timeout));
        }
        else
        {
            services.AddHttpClient(clientName, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(timeout);
            })
            .AddPolicyHandler((provider, _) => GetRetryPolicy(provider, retryCount))
            .AddPolicyHandler((provider, _) => GetCircuitBreakerPolicy(provider))
            .AddPolicyHandler(GetTimeoutPolicy(timeout));
        }
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IServiceProvider provider, int retryCount)
    {
        var logger = provider.GetService<ILogger<HttpClient>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(
                retryCount,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    logger?.LogWarning(
                        "Retry {RetryAttempt} for {PolicyKey} at {OperationKey}, due to: {Exception}",
                        retryAttempt,
                        context.PolicyKey,
                        context.OperationKey,
                        outcome.Exception?.Message);
                });
    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(IServiceProvider provider)
    {
        var logger = provider.GetService<ILogger<HttpClient>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 2,
                durationOfBreak: TimeSpan.FromSeconds(30),
                onBreak: (outcome, breakDelay) =>
                {
                    logger?.LogError(
                        "Circuit breaker opened for {BreakDelay} seconds due to: {Exception}",
                        breakDelay.TotalSeconds,
                        outcome.Exception?.Message);
                },
                onReset: () =>
                {
                    logger?.LogInformation("Circuit breaker reset");
                },
                onHalfOpen: () =>
                {
                    logger?.LogInformation("Circuit breaker is half-open, testing next request");
                });
    }

    private static IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy(int timeout)
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(timeout));
    }
}
