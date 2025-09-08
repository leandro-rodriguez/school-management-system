using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ICourseGroupService : IActiveService<CourseGroup>
{
    // Selecciona un CourseGroup con cierto id
    // y toma toda su informaci�n
    CourseGroup GetCourseGroupById(string id);
}