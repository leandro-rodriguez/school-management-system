using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ITuitorService : IActiveService<Tuitor>
{
    // Selecciona a un tutor con cierto id
    // y toma toda su informaci�n
    Tuitor GetTuitorById(string id);
}