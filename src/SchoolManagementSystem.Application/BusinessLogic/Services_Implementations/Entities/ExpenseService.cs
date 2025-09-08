
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class ExpenseService : ActiveService<Expense>, IExpenseService
{
    public ExpenseService(IExpenseRepository repository) : base(repository)
    {

    }

    public override IQueryable<Expense> Query()
    {
        return base.Query().Include(e => e.ExpenseRecords).AsNoTracking();
    }
}