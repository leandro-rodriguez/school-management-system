
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class StudentService : ActiveService<Student>, IStudentService
{
    public StudentService(IStudentRepository repository) : base(repository)
    {

    }

    public Student GetStudentById(string id)
    {
        return Query()
            .Where(student => student.Id == id) 
            .Include(student => student.StudentCourseGroupRelations)
            .FirstOrDefault();
    }

    public override IQueryable<Student> Query()
    {
        return base.Query()
            .Include(student => student.Tuitor);
    }
}