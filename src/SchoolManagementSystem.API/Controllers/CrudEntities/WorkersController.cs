
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore;  
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class WorkersController : CrudController<Worker, WorkerDto>
{
    
    public WorkersController(IWorkerService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }

    public override IActionResult Delete(string id)
    {
        var workers = _service.Query()
            .AsNoTrackingWithIdentityResolution().Include(c => c.WorkerPositionRelations);
        var Worker = workers.FirstOrDefault(c => Equals(c.Id, id));
        
        if(Worker == null)
            return NotFound(id);

        foreach(var rel in Worker.WorkerPositionRelations)
        {
            if (DateTime.Now <  rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }

        return base.Delete(id);
    }

}
