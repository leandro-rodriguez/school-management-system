
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class ResourceDto : IDto
{
    public string Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MaxLength(30)]
    public string Category { get; set; }

    [Required]
    [Range(1, 9999)]
    [DataType(DataType.Currency)]
    // [Column(TypeName = "money")]
    public int Price { get; set; }

    // [Required]
    // [MinLength(1)]
    // public IList<Worker> Providers { get; set; }
}
