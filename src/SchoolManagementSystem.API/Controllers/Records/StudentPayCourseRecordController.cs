
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class StudentPayCourseRecordController : RecordController<StudentPaymentRecordPerCourseGroup, StudentPayCourseRecordDto>
{
    public StudentPayCourseRecordController(IStudentPayCourseRecordService service,
        IMapper mapper) : base(service, mapper)
    {
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.Query()
            .Include(s => s.CourseGroup.Course)
            .Select(_mapperToDto.Map<StudentPaymentRecordPerCourseGroup, StudentPayCourseRecordDto>)
            .ToList());
    }

    [HttpGet("{id}")]
    public IActionResult PaymentByStudentId(string id)
    {
        if (_service.Query().FirstOrDefault(s => s.StudentId == id) == null)
        {
            return NotFound(id);
        }
        
        return Ok
        (
            _service.Query()
                .Where(s => s.StudentId == id)
                .Include(s => s.CourseGroup.Course)
                .Select(s => new StudentPayCourseRecordDto
                {
                    DatePaid = s.DatePaid,
                    Payment = s.CourseGroup.Course.Price,
                    CourseName = s.CourseGroup.Course.Name
                })
                .ToList()                
        );
    }
}
