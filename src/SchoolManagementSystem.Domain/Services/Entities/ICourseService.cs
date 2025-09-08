using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ICourseService : IActiveService<Course>
{
    // Selecciona un curso con cierto id
    // y toma toda su informaci�n
    Course GetCourseById(string id);
}