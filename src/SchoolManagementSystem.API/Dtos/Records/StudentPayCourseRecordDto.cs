
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class StudentPayCourseRecordDto
{
    public string CourseName { get; set; }
    public int Payment { get; set; }
    public DateTime DatePaid { get; set; }
}
