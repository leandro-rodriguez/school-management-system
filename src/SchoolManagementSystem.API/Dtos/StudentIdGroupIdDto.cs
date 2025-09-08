

using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;


public class StudentIdGroupIdDto
{
    [Required]
    public string StudentId { get; set; }
    [Required]
    public string GroupId { get; set; }
}