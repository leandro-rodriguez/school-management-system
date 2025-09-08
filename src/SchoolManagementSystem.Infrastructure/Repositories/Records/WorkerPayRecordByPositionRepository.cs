
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Configurations.Records;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories.Records
{
    public class WorkerPayRecordByPositionRepository :  RecordRepository<WorkerPayRecordByPosition>, IWorkerPayRecordByPositionRepository
    {
        public WorkerPayRecordByPositionRepository(IObjectContext context) : base(context)
        {
        }
    }

}
