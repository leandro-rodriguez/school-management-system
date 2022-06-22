
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class CourseGroupService : BaseService<CourseGroup>, ICourseGroupService
{
    public CourseGroupService(ICourseGroupRepository repository) : base(repository)
    {

    }

    public CourseGroup GetCourseGroupById(string id)
    {
        return Query()
            .Where(courseGroup => courseGroup.Id == id) 
            .Include(courseGroup => courseGroup.Course)
            .Include(courseGroup => courseGroup.StudentCourseGroupRelations)            
            .FirstOrDefault();
    }
}