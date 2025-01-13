using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.UserDTOs
{
    public record LinkCourseRequestDTO
    {
        [Required]
        public Guid CourseId { get; init; }
    }
}
