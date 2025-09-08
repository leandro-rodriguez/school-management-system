
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class CourseGroupsController : CrudController<CourseGroup, CourseGroupDto>
{

    public CourseGroupsController(ICourseGroupService service,
        IMapper mapper) : base(service, mapper)
    {
    }

    public override IActionResult Delete(string id)
    {
        var courseGruops = _service.Query()
            .AsNoTrackingWithIdentityResolution().Include(c => c.StudentCourseGroupRelations)
                                                .Include(c => c.TeacherCourseGroupRelations);
        var courseGroup = courseGruops.FirstOrDefault(c => Equals(c.Id, id));

        if (courseGroup == null)
            return NotFound(id);

        foreach (var rel in courseGroup.TeacherCourseGroupRelations)
        {
            if (DateTime.Now < rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }

        foreach (var rel in courseGroup.StudentCourseGroupRelations)
        {
            if (DateTime.Now < rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }
        

        return base.Delete(id);
    }
}
