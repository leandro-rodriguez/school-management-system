using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface IStudentService : IActiveService<Student>
{
    // Selecciona a un estudiante con cierto id
    // y toma toda su informaci�n
    Student GetStudentById(string id);
}