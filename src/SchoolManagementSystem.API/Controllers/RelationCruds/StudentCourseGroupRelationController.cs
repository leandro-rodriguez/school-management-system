
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
public class StudentCourseGroupRelationController : Controller
{
    public readonly IStudentCourseGroupRelationService _service;
    public readonly IMapper mapper;
    
    public StudentCourseGroupRelationController(IStudentCourseGroupRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var _query = _service.Query().Include(c => c.CourseGroup.Course).Include(c => c.Student);
        List<StudentCourseGroupRelationDto> output = new List<StudentCourseGroupRelationDto>();   
        foreach (var item in _query)
        {
            StudentCourseGroupRelationDto dto = new StudentCourseGroupRelationDto(){
               CourseGroupCourseId = item.CourseGroupCourseId,
               CourseGroupCourseName = item.CourseGroup.Course.Name,
               CourseType = item.CourseGroup.Course.Type,
               CourseGroupName = item.CourseGroup.Name,
               StudentName = item.Student.Name,
               StudentId = item.StudentId,
               CourseGroupId = item.CourseGroupId,
               EndDate = item.EndDate,
               StartDate = item.StartDate               
            };
            output.Add(dto);
        }
        return Ok(output);
    }
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var _query = _service.Query().Where(c => c.StudentId == id).Include(c => c.CourseGroup.Course).Include(c => c.Student);
        List<StudentCourseGroupRelationDto> output = new List<StudentCourseGroupRelationDto>();   
        foreach (var item in _query)
        {
            StudentCourseGroupRelationDto dto = new StudentCourseGroupRelationDto(){
               CourseGroupCourseId = item.CourseGroupCourseId,
               CourseGroupCourseName = item.CourseGroup.Course.Name,
               CourseType = item.CourseGroup.Course.Type,
               CourseGroupName = item.CourseGroup.Name,
               StudentName = item.Student.Name,
               StudentId = item.StudentId,
               CourseGroupId = item.CourseGroupId,
               EndDate = item.EndDate,
               StartDate = item.StartDate               
            };
            output.Add(dto);
        }
        return Ok(output);
    }

    [HttpPost]
    public IActionResult Post([FromBody]StudentCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.StudentId, dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        _service.Add(new StudentCourseGroupRelation
        {
            CourseGroupId = dto.CourseGroupId,
            StudentId = dto.StudentId,
            CourseGroupCourseId = dto.CourseGroupCourseId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        });
        _service.CommitAsync();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody]StudentCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.StudentId, dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        var relation = new StudentCourseGroupRelation
        {
            CourseGroupId = dto.CourseGroupId,
            StudentId = dto.StudentId,
            CourseGroupCourseId = dto.CourseGroupCourseId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
        _service.Update(relation);
        _service.CommitAsync();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody]StudentCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.StudentId, dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        var item = _service.Query().Where(
                    c => c.CourseGroupId == dto.CourseGroupId
                    && c.StudentId == dto.StudentId
                    && c.CourseGroupCourseId == dto.CourseGroupCourseId
                    && c.StartDate == dto.StartDate
                ).FirstOrDefault();
        if (item != null)
            _service.Remove(item);
        _service.CommitAsync();
        return Ok();
    }

}
