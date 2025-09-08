

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface IShiftsService : IService<Shift>
{
    
    public bool ValidateClassroomIds(string classroomId);
}