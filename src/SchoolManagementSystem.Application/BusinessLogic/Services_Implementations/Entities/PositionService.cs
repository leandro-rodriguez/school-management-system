
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class PositionService : ActiveService<Position>, IPositionService
{
    public PositionService(IPositionRepository repository) : base(repository)
    {

    }
}