

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
public class CourseCourseGroupRelationController : Controller
{
    public readonly ICourseGroupService _service;
    public readonly IMapper mapper;
    
    public CourseCourseGroupRelationController(ICourseGroupService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    // [HttpGet]
    // public IActionResult GetAll()
    // {
    //     var _query = _service.Query().Include(c => c.Teacher).Include(c => c.Course);

    //     return Ok(_query.Select(mapper.Map<TeacherCourseRelation,TeacherCourseRelationDto>));
    // }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        List<CourseGroupDto> list = new List<CourseGroupDto>();
        
        var _query = _service.Query()
            .Where(c => c.CourseId == id)
            .Include(c=>c.StudentCourseGroupRelations)
            .Include(c => c.Teacher);
        
        foreach (var item in _query)
        {
            var single  = mapper.Map<CourseGroupDto>(item);
            single.TotalStudents = item.StudentCourseGroupRelations.Count();
            list.Add(single);
        }

        return Ok(list);
    }
//     [HttpGet("{TeacherId}, {CourseId}")]
//     public IActionResult GetAll(string TeacherId,string CourseId)
//     {
//         var _query = _service.Query().Include(c => c.Teacher).Include(c => c.Course)
//                        .Where(c=> c.TeacherId == TeacherId
//                             && c.CourseId == CourseId
//                        );

//         return Ok(_query.Select(mapper.Map<TeacherCourseRelation,TeacherCourseRelationDto>));
//     }

//     [HttpPost]
//     public IActionResult Post([FromBody]TeacherCourseRelationDto dto)
//     {
//         if(!_service.ValidateIds(dto.TeacherId, dto.CourseId))
//             return NotFound();
//         _service.Add(mapper.Map<TeacherCourseRelation>(dto));
//         _service.CommitAsync();
//         return Ok();
//     }

//     [HttpPut]
//     public IActionResult Put([FromBody]TeacherCourseRelationDto dto)
//     {
//         if(!_service.ValidateIds(dto.TeacherId, dto.CourseId))
//             return NotFound();
//         var relation = mapper.Map<TeacherCourseRelation>(dto);
//         _service.Update(relation);
//         _service.CommitAsync();
//         return Ok();
//     }

//     [HttpDelete]
//     public IActionResult Delete([FromBody]TeacherCourseRelationDto dto)
//     {
//         if(!_service.ValidateIds(dto.TeacherId, dto.CourseId))
//             return NotFound();
//         var item = _service.Query().Where(
//                     c => c.TeacherId == dto.TeacherId
//                     && c.CourseId == dto.CourseId
//                 ).FirstOrDefault();
//         if (item != null)
//             _service.Remove(item);
//         _service.CommitAsync();
//         return Ok();
//     }

}
