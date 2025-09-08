
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class AdditionalServiceDto : IDto
{
    public string Id { get; set; }

    [Required]
    public string WorkerId { get; set; }
    [Required]
    public string ResourceId { get; set; }
    [Required]
    public int WorkerPorcentageProfits { get; set; }

}
