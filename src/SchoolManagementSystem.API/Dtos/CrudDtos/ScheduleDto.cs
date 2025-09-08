
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class ScheduleDto : IDto
{
    public string Id { get; set; }

    [Required]
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:hh-mm-ss}",
         ApplyFormatInEditMode = true)]
    public TimeOnly Duration { get; set; }

    [Required]
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:hh-mm-ss}",
        ApplyFormatInEditMode = true)]
    public TimeOnly StartTime { get; set; }

    [Required]
    public DayOfWeek DayOfWeek { get; set; }
}