
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class CourseService : ActiveService<Course>, ICourseService
{
    public CourseService(ICourseRepository repository) : base(repository)
    {

    }

    public Course GetCourseById(string id)
    {
        return Query()
            .Where(course => course.Id == id)
            .Include(course => course.TeacherCourseRelations)            
            .Include(course => course.CourseGroups)
            .FirstOrDefault();
    }
}