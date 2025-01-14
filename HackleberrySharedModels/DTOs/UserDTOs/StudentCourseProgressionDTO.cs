using System.ComponentModel.DataAnnotations;
using HackleberryModels.DTOs.CourseProgressionDTOs;

namespace HackleberrySharedModels.DTOs.UserDTOs;

public class StudentCourseProgressionDTO
{
    public Guid StudentId { get; set; }
    public List<CourseProgressionDTO> Courses { get; set; } = new List<CourseProgressionDTO>();
}