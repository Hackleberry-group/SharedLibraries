using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class PutTeacherDTO
{
    [Required(ErrorMessage = "Id is required.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Employee number is required.")]
    public string TeacherNumber { get; set; }
}