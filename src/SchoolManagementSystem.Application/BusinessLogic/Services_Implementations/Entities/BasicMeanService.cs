
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class BasicMeanService : ActiveService<BasicMean>, IBasicMeanService
{
    public BasicMeanService(IBasicMeanRepository repository) : base(repository)
    {
        
    }
}   