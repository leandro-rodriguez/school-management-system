

using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionSalaryController : Controller
{
    public readonly IWorkerPositionRelationService _service;
    public readonly IMapper mapper;
    
    public PositionSalaryController(IWorkerPositionRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var _query = _service.Query()
            .Where(c=>c.WorkerId == id)
            .Include(c => c.Worker)
            .Include(c => c.Position);
        
        var listOfPositionSalary = new List<PositionSalaryRelDto>();
        
        foreach (var row in _query)
        {
            PositionSalaryRelDto single = new PositionSalaryRelDto
            {
                Position = row.Position.Name,
                FixedSalary = row.FixedSalary
            };
            listOfPositionSalary.Add(single);
        }

        return Ok(listOfPositionSalary);
    }

}
