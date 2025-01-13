using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.UserDTOs;

public record LinkStudentRequestDTO
{
    [Required]
    public Guid StudentId { get; init; }
}
