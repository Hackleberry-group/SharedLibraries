using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LogoutDTO 
    { 
        [Required]
        public required string UserId { get; init; }
    }
}