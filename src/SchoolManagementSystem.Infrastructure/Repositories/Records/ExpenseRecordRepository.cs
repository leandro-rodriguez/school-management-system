using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ExpenseRecordRepository : RecordRepository<ExpenseRecord>, IExpenseRecordRepository
{
    public ExpenseRecordRepository(IObjectContext context) : base(context)
    {

    }
}