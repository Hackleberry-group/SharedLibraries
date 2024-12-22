using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserService;

public class CreateTeacherDTO
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Employee number is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Employee number must be a positive integer.")]
    public int EmployeeNumber { get; set; }
}