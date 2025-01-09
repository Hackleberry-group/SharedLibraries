using System.ComponentModel.DataAnnotations;

namespace HackleberryModels.DTOs.CourseServiceDTOs
{
    public class ModuleResponseDTO
    {
        [Required]
        public Guid Id { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public Guid CourseId { get; init; }

        [Required]
        public int Order { get; init; }

        [Required]
        public List<Guid> TopicIds { get; init; } = new List<Guid>();
    }
}
