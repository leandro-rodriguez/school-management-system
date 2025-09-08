
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Entities;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;

public class ExpenseDto : IDto
{
    [JsonPropertyName("key")]
    public string Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Category { get; set; }  

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
}
