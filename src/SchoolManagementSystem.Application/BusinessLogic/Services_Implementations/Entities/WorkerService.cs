
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class WorkerService : ActiveService<Worker>, IWorkerService
{
    public WorkerService(IWorkerRepository repository) : base(repository)
    {

    }

    public Worker GetWorkerById(string id)
    {
        return Query()
            .Where(w => w.Id == id)
            .Include(w => w.Services)
            .Include(w => w.AdditionalServices)            
            .FirstOrDefault();
    }

    public override IQueryable<Worker> Query()
    {
        return base.Query().Include(w => w.Positions);
    }
}