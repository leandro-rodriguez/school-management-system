
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class WorkerPositionRelationService : BaseService<WorkerPositionRelation>, IWorkerPositionRelationService
{
    IWorkerPositionRelationRepository repo;
    IWorkerRepository wkr_repo;
    IPositionRepository pst_repo;
    public WorkerPositionRelationService(IWorkerRepository wkr_repo,
            IPositionRepository pst_repo,
             IWorkerPositionRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.pst_repo = pst_repo;
        this.wkr_repo = wkr_repo;
    }
    public bool ValidateIds(string WorkerId, string PositionId)
    {
        var row = wkr_repo.Query().Where(c => c.Id == WorkerId)
                            .FirstOrDefault();

        if (row == null)
            return false;

        var std = pst_repo.Query().Where(c => c.Id == PositionId)
                            .FirstOrDefault();
        if (std == null)
            return false;

        return true;
    }
}