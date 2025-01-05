using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class PutGroupDTO
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "TeacherId is required.")]
    public Guid TeacherId { get; set; }
}