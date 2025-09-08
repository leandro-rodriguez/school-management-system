
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class ShiftDto : IDto
{
    public string Id { get; set; }

    [Required]
    public string ClassroomId { get; set; }


    [Required]
    public string ScheduleId { get; set; }
}
