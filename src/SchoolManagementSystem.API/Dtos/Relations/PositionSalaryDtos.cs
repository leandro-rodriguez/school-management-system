

using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos;

public class PositionSalaryRelDto
{
    // [Required]
    // public string WorkerId { get; set; }
    // [Required]
    [Required]
    public int FixedSalary { get; set; }
    // public string PositionId { get; set; }
    // [Required]
    public string Position { get; set; }
    // [Required]
    // public int FixedSalary { get; set; }
}

