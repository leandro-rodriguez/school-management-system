
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.Relations;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class StudentsController : CrudController<Student, StudentDto>
{
    
    public StudentsController(IStudentService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }

    [HttpGet()]
    [Route("Inactive")]
    public IActionResult Get()
    {
        //if (active)
        //{
        //    return Ok(_service.Query()
        //            .Select(_mapperToDto.Map<Student, StudentDto>)
        //            .ToList());
        //}
        return Ok(_service.QueryInactives()
                    .Select(_mapperToDto.Map<Student, StudentDto>)
                    .ToList());
    }

    [HttpPost("{id}")]
    public IActionResult Restore(string id)
    {
        var inactiveStudent = _service.QueryInactives().SingleOrDefault(c => c.Id == id);
        if (inactiveStudent != null)
        {
            inactiveStudent.Active = true;
            _service.Update(inactiveStudent);
            _service.CommitAsync();

            return Ok(id);
        }
        return NotFound(id);
    }

    [HttpPost]
    public override IActionResult Post([FromBody] StudentDto dto_model)
    {
        var inactiveStudent = _service.QueryInactives().SingleOrDefault(c => c.IDCardNo == dto_model.IDCardNo && c.Name == dto_model.Name);
        if(inactiveStudent != null)
        {
            inactiveStudent.Active = true;
            _service.Update(inactiveStudent);
            _service.CommitAsync();

            dto_model.Id = inactiveStudent.Id;
            return Ok(dto_model);
        }


        var tuitor = new Tuitor 
        { 
            Name = dto_model.TuitorName, 
            PhoneNumber = dto_model.TuitorPhoneNumber,
            Students = new List<Student>() 
        };

        var studentTuitor = _service.Query()
                    .Where(
                        s => s.Tuitor.Name == dto_model.TuitorName
                            && s.Tuitor.PhoneNumber == dto_model.TuitorPhoneNumber
                    )
                    .FirstOrDefault();

        if (studentTuitor is not null)
        {
            tuitor = studentTuitor.Tuitor;
        }
        if(tuitor.Name == "")
            tuitor = null;

        var scholarityLevel = _mapperToDto.Map<Education>(dto_model.ScholarityLevel);


        var student = _mapperToDto.Map<Student>(dto_model);
        student.Id = Guid.NewGuid().ToString();
        dto_model.Id = student.Id;

        student.Tuitor = tuitor;
        student.StudentCourseGroupRelations = new List<StudentCourseGroupRelation>();
        student.ScholarityLevel = scholarityLevel;
        
        _service.Add(student);
        _service.CommitAsync();
        
        
        return Ok(dto_model);
    }

    [HttpPut]
    public override IActionResult Put([FromBody] StudentDto dto_model)
    {
        var entities = _service.Query().Include(c => c.Tuitor);
        var entity = entities.FirstOrDefault(c => Equals(c.Id, dto_model.Id));

        if(entity == null)
            return NotFound(dto_model);
        
        _mapperToDto.Map(dto_model, entity);
        entity.Tuitor.Name = dto_model.TuitorName;
        entity.Tuitor.PhoneNumber = dto_model.TuitorPhoneNumber;


        _service.Update(entity);
        _service.CommitAsync();
        
        return Ok();
    }

    public override IActionResult Delete(string id)
    {
        var students = _service.Query()
            .AsNoTrackingWithIdentityResolution().Include(c => c.StudentCourseGroupRelations);
        var student = students.FirstOrDefault(c => Equals(c.Id, id));
        
        if(student == null)
            return NotFound(id);

        foreach(var rel in student.StudentCourseGroupRelations)
        {
            if (DateTime.Now <  rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }

        return base.Delete(id);
    }
}
