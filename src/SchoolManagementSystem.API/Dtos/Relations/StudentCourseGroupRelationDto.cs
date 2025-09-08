
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos;

public class StudentCourseGroupRelationDto
{
    [Required]
    public string CourseGroupId { get; set; }
    public string CourseGroupName{get; set; }

    [Required]
    public string CourseGroupCourseId { get; set; }
    public string CourseGroupCourseName{get; set; }
    public string CourseType{get; set; }

    [Required]
    public string StudentId{get; set;}
    public string StudentName{get; set;}
    // [Required]
    [Required]
    public DateTime StartDate {get; set;}
    // [Required]
    public DateTime EndDate {get; set;}
}

