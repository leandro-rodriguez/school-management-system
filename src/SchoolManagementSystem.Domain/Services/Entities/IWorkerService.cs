using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface IWorkerService : IActiveService<Worker>
{
    // Selecciona al trabajador con cierto id
    // y toma toda su informaci�n
    Worker GetWorkerById(string id);
}