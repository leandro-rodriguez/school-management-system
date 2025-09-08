
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrudController<TEntity, TDTO> : Controller where TEntity :  Entity where TDTO : IDto
{
    public readonly IActiveService<TEntity> _service;
    public readonly IMapper _mapperToDto;
    
    public CrudController(IActiveService<TEntity> service, 
        IMapper mapperToDto)
    {
        _service = service;
        _mapperToDto = mapperToDto;
    }

    [HttpGet]
    public virtual IActionResult GetAll()
    {
        return Ok
        (
            _service.Query()
                .Select(_mapperToDto.Map<TEntity,TDTO>)
                .ToList()
        );
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItemById(string id)
    {
        var entities = _service.Query()
            .AsNoTrackingWithIdentityResolution();
        
        var entity = entities
            .FirstOrDefault(c => Equals(c.Id, id));
        if (entity == null)
        {
            return NotFound(id);
        }        
        return Ok(_mapperToDto.Map<TDTO>(entity));
    }

    [HttpPost]
    public virtual IActionResult Post([FromBody] TDTO dto_model)
    {
        var entity = _mapperToDto.Map<TEntity>(dto_model);

        entity.Id = Guid.NewGuid().ToString();
        
        _service.Add(entity);
        _service.CommitAsync();

        dto_model.Id = entity.Id;
        
        return Ok(dto_model);
    }

    [HttpPut]
    public virtual IActionResult Put([FromBody] TDTO dto_model)
    {
        var entities = _service.Query();
        var entity = entities.FirstOrDefault(c => Equals(c.Id, dto_model.Id));

        if(entity == null)
            return NotFound(dto_model);
        
        _mapperToDto.Map(dto_model, entity);
        _service.Update(entity);
        _service.CommitAsync();
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public virtual IActionResult Delete(string id)
    {
        var entities = _service.Query()
            .AsNoTrackingWithIdentityResolution();
        
        var entity = entities.FirstOrDefault(c => Equals(c.Id, id));
        
        if(entity == null)
            return NotFound(id);
        
        entity.Active = false;
        _service.Update(entity);
        _service.CommitAsync();
        
        return Ok();
    }
}
