
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;

public class CourseDto : IDto
{
    [JsonPropertyName("key")]
    public string Id { get; set; }

    [Required]
    public int Price { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public string Name { get; set; }
}
