using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class TuitorRepository : ActiveRepository<Tuitor>, ITuitorRepository
{
    public TuitorRepository(IObjectContext context) : base(context)
    {

    }
}