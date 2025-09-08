

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
public class WorkerPositionRelationController : Controller
{
    public readonly IWorkerPositionRelationService _service;
    public readonly IMapper mapper;
    
    public WorkerPositionRelationController(IWorkerPositionRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var _query = _service.Query().Include(c => c.Worker).Include(c => c.Position);
        return Ok(_query.Select(mapper.Map<WorkerPositionRelation,WorkerPositionRelationDto>));
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var _query = _service.Query()
            .Where(c=>c.WorkerId == id)
            .Include(c => c.Worker)
            .Include(c => c.Position);
        
        return Ok(_query.Select(mapper.Map<WorkerPositionRelationDto>));
    }

    [HttpPost]
    public IActionResult Post([FromBody]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        _service.Add(mapper.Map<WorkerPositionRelation>(dto));
        _service.CommitAsync();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        var relation = mapper.Map<WorkerPositionRelation>(dto);
        _service.Update(relation);
        _service.CommitAsync();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        var item = _service.Query().Where(
                    c => c.WorkerId == dto.WorkerId
                    && c.PositionId == dto.PositionId
                ).FirstOrDefault();
        if (item != null)
            _service.Remove(item);
        _service.CommitAsync();
        return Ok();
    }

}
