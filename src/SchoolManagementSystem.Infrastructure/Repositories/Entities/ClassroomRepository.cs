
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
// using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ClassroomRepository : ActiveRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(IObjectContext context) : base(context)
    {

    }
}
