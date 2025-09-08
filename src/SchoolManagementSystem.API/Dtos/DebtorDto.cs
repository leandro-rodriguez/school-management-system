

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;


public class DebtorDto
{
    [Required]
    [JsonPropertyName("key")]
    public string StudentId { get; set; }

    [Required]
    [JsonPropertyName("CI")]
    public string IDCardNo { get; set; }

    [Required]
    [MaxLength(20)]
    [JsonPropertyName("name")]
    public string StudentName { get; set; }

    [Required]
    [MaxLength(30)]
    [JsonPropertyName("lastName")]
    public string StudentLastName { get; set; }

    [Required]
    [JsonPropertyName("groupKey")]
    public string GroupId { get; set; }

    [Required]
    [JsonPropertyName("group")]
    public string GroupName { get; set; }
    [Required]
    [JsonPropertyName("debt")]
    public int Debt { get; set; }
    [Required]
    [JsonPropertyName("dealy")]
    public int Dealy { get; set; }
    //[Required]
    //public string CourseId { get; set; }
    //[Required]
    //public DateTime DatePaid { get; set; }
    //[Required]
    //public DateTime EndDate { get; set; }
    //[Required]
    //public DateTime Date { get; set; }
}