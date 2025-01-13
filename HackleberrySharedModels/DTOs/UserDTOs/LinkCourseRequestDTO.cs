using System.ComponentModel.DataAnnotations;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class LinkCourseRequestDTO
{
    public Guid CourseId { get; set; }
}