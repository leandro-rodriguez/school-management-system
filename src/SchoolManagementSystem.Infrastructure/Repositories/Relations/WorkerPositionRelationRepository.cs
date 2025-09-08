
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class WorkerPositionRelationRepository :  CrudRepository<WorkerPositionRelation>, IWorkerPositionRelationRepository
    {
        public WorkerPositionRelationRepository(IObjectContext context) : base(context)
        {
     
        }
    }

}
