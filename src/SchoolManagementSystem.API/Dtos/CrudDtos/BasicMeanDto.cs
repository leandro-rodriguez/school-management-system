
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;
public class BasicMeanDto : IDto
{
    [JsonPropertyName("key")]
    public string Id { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    [MaxLength(20)]
    public string Type { get; set; }

    [Required]
    [MaxLength(30)]
    public string Origin { get; set; }

    [Required]
    public int DevaluationInTime { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                  ApplyFormatInEditMode = true)]
    public DateTime InaugurationDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
}