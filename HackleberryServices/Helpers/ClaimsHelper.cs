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
        return IsInRole(user, Roles.TeacherRole);
    }

    public static bool IsStudent(ClaimsPrincipal user)
    {
        return IsInRole(user, Roles.StudentRole);
    }

    public static bool IsAdmin(ClaimsPrincipal user)
    {
        return IsInRole(user, Roles.AdminRole);
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
        public const string RequireAdminRole = "RequireAdminRole";
        public const string RequireTeacherRole = "RequireTeacherRole";
        public const string RequireStudentRole = "RequireStudentRole";
    }

    public static class Roles
    {
        public static readonly string AdminRole = "Admin";
        public static readonly string TeacherRole = "Teacher";
        public static readonly string StudentRole = "Student";
    }
}

