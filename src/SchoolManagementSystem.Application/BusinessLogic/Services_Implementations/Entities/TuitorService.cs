
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class TuitorService : ActiveService<Tuitor>, ITuitorService
{
    public TuitorService(ITuitorRepository repository) : base(repository)
    {

    }

    public Tuitor GetTuitorById(string id)
    {
        return Query()
            .Where(tuitor => tuitor.Id == id)                        
            .Include(tuitor => tuitor.Students)            
            .FirstOrDefault();
    }
}