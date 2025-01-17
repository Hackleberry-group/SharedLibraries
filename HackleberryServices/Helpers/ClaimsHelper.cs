using System.Security.Claims;

namespace HackleberryServices.Helpers;

public static class ClaimsHelper
{
    public static Guid GetUserId(ClaimsPrincipal user)
    {
        var subClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return subClaim != null ? Guid.Parse(subClaim) : Guid.Empty;
    }

    public static bool IsInRole(ClaimsPrincipal user, string role)
    {
        return user.IsInRole(role);
    }

    public static bool IsTeacher(ClaimsPrincipal user)
    {
        return IsInRole(user, Roles.Teacher);
    }

    public static bool IsStudent(ClaimsPrincipal user)
    {
        return IsInRole(user, Roles.Student);
    }

    public static bool IsAdmin(ClaimsPrincipal user)
    {
        return IsInRole(user, Roles.Admin) || user.HasClaim(ClaimTypes.AuthenticationMethod, "ApiKey");
    }

    public static string? GetUserEmail(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Email)?.Value;
    }

    public static string? GetUserName(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }

    public static class Policies
    {
        public const string RequireAdminRole = "MultiAuth_Admin";
        public const string RequireTeacherRole = "MultiAuth_Admin_Teacher";
        public const string RequireStudentRole = "MultiAuth_Admin_Student";
        public const string AllowAll = "MultiAuth_Admin_Student_Teacher";
    }

    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Teacher = "Teacher";
        public const string Student = "Student";
    }
}

