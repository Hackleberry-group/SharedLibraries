using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class CreateTeacherDTO
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email is not valid.")]
    public string Email { get; init; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
    public string Password { get; init; }

    [Required(ErrorMessage = "Teacher number is required.")]
    [StringLength(5, MinimumLength=5, ErrorMessage = "Teacher number must be 5 numbers.")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Teacher number must be numeric.")]
    public string TeacherNumber { get; init; }
}