
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : Controller
{
    public readonly IShiftsService _service;
    public readonly IMapper mapper;
    
    public ShiftsController(IShiftsService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    // [HttpGet]
    // public IActionResult GetAll()
    // {
    // }
    [HttpGet("{classroomId}")]
    public IActionResult Get(string classroomId)
    {
        if(!_service.ValidateClassroomIds(classroomId))
            return NotFound();
        
        List<ShiftsDto> answer = new List<ShiftsDto>();

        foreach (var item in _service.Query().Where(c => c.ClassroomId == classroomId).Include(c => c.Schedule))
        {
            var single = new ShiftsDto
            {
                ClassroomId = classroomId,
                Classroom = item.Classroom.ToString(),
                Description = item.Description,
                ScheduleEndTime = item.Schedule.EndTime.ToString(),
                ScheduleStartTime = item.Schedule.StartTime.ToString(),
                ScheduleId = item.ScheduleId
            };
            answer.Add(single);
        }

        return Ok(answer);
    }

    // [HttpPost]
    // public IActionResult Post([FromBody]StudentCourseGroupRelationDto dto)
    // {
    // }

    // [HttpPut]
    // public IActionResult Put([FromBody]StudentCourseGroupRelationDto dto)
    // {
    // }

    // [HttpDelete]
    // public IActionResult Delete([FromBody]StudentCourseGroupRelationDto dto)
    // {
    // }

}
