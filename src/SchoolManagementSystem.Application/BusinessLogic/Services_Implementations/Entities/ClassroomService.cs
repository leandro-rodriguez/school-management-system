
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class ClassroomService : ActiveService<Classroom>, IClassroomService
{
    public ClassroomService(IClassroomRepository repository) : base(repository)
    {
        
    }
}   