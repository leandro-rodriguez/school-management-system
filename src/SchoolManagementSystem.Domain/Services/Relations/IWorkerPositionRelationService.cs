

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface IWorkerPositionRelationService : IService<WorkerPositionRelation>
{
    public bool ValidateIds(string WorkerId, string PositionId);
}