using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.AuthDTOs
{
    public record LogoutDTO 
    { 
        [Required]
        public string UserId { get; init; }
    }
}