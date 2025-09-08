
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;


public class StudentDto : SchoolMemberDto
{

    
    public string TuitorId { get; set; }

    // [Required]
    public string TuitorName { get; set; }
    
    // [Required]
    public int TuitorPhoneNumber { get; set; }

    // [Required]
    public int Founds { get; set; } = 0;

    [Required]
    public string ScholarityLevel { get; set; }
}
