using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.CourseServiceDTOs
{
    public class CourseRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength=1)]
        public required string Name { get; init; }
        
        [Required]
        public string ProgrammingLanguage { get; init; }

        [Required]
        public required Guid TeacherId { get; init; }
    }
}
