
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos;

public class TeacherCourseGroupRelationDto
{
    [Required]
    public string TeacherId { get; set; }
    // [Required]
    public string TeacherName { get; set; }
    [Required]
    public string CourseGroupId { get; set; }
    // [Required]
    public string CourseGroupName { get; set; }
    [Required]
    public string CourseGroupCourseId { get; set; }
    public string CourseGroupCourseName { get; set; }
    // [Required]
    // public int CorrespondingPorcentage { get; set; }
}

