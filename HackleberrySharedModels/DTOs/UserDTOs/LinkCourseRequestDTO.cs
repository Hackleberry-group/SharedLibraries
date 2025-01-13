using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs
{
    public record LinkCourseRequestDTO
    {
        [Required]
        public Guid CourseId { get; init; }
    }
}
