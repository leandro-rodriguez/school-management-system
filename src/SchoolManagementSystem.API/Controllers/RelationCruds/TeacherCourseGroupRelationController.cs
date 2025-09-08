

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
public class TeacherCourseGroupRelationController : Controller
{
    public readonly ITeacherCourseGroupRelationService _service;
    public readonly IMapper mapper;
    
    public TeacherCourseGroupRelationController(ITeacherCourseGroupRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var _query = _service.Query().Include(c => c.Teacher).Include(c => c.CourseGroup.Course);

        return Ok(_query.Select(mapper.Map<TeacherCourseGroupRelation,TeacherCourseGroupRelationDto>));
    }

    [HttpPost]
    public IActionResult Post([FromBody]TeacherCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.TeacherId,dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        TeacherCourseRelation item = mapper.Map<TeacherCourseRelation>(mapper.Map<TeacherCourseRelationDto>(dto));
        item.CourseId = dto.CourseGroupCourseId;
        _service.AddTeacherCourseRelation(item);
        _service.Add(mapper.Map<TeacherCourseGroupRelation>(dto));
        _service.CommitAsync();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody]TeacherCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.TeacherId, dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        var relation = mapper.Map<TeacherCourseGroupRelation>(dto);
        _service.Update(relation);
        _service.CommitAsync();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody]TeacherCourseGroupRelationDto dto)
    {
        if(!_service.ValidateIds(dto.TeacherId, dto.CourseGroupId, dto.CourseGroupCourseId))
            return NotFound();
        var item = _service.Query().Include(c => c.CourseGroup.Course).Where(
                    c => c.TeacherId == dto.TeacherId
                    && c.CourseGroupId == dto.CourseGroupId
                    && c.CourseGroup.Course.Id == dto.CourseGroupCourseId
                ).FirstOrDefault();
        if (item != null)
            _service.Remove(item);
        _service.CommitAsync();
        return Ok();
    }

}
