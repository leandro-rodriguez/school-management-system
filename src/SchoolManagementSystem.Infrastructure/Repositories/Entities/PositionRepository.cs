using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class PositionRepository : ActiveRepository<Position>, IPositionRepository
{
    public PositionRepository(IObjectContext context) : base(context)
    {

    }
}