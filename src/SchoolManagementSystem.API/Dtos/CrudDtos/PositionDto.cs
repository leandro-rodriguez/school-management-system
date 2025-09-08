
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class PositionDto : IDto
{
    [JsonPropertyName("key")]
    public string Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
}
