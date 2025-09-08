using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class StudentRepository : ActiveRepository<Student>, IStudentRepository
{
    public StudentRepository(IObjectContext context) : base(context)
    {
        
    }

    public Student GetById(string id)
    {
        return Query().Where(s => s.Id == id).FirstOrDefault();
    }
}