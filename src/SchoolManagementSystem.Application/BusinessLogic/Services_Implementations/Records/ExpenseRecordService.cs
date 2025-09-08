
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class ExpenseRecordService : BaseRecordService<ExpenseRecord>, IExpenseRecordService
{
    public ExpenseRecordService(IExpenseRecordRepository repository) : base(repository)
    {

    }
}