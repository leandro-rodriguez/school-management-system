

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;


public class StudentGroupPaymentDto
{
    [Required]
    public string StudentId { get; set; }
    [Required]
    public string GroupId { get; set; }
    [Required]
    public string GroupName { get; set; }
    [Required]
    public string CourseId { get; set; }
    [Required]
    [JsonPropertyName("price")]
    public int CoursePrice { get; set; }
    [Required]
    public DateTime DatePaid { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public DateTime Date { get; set; }
}