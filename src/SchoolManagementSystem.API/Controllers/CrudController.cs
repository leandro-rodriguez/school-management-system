
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrudController<TEntity, TDTO> : Controller where TEntity :  Entity where TDTO : IDto
{
    public readonly IService<TEntity> _service;
    public readonly IMapper _mapperToDto;
    
    public CrudController(IService<TEntity> service, 
        IMapper mapperToDto)
    {
        _service = service;
        _mapperToDto = mapperToDto;
    }

    [HttpGet]
    public IActionResult GetAll()
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
        
        return Ok(entity);
    }

    [HttpPost]
    public virtual IActionResult Post([FromForm] TDTO dto_model)
    {
        var entity = _mapperToDto.Map<TEntity>(dto_model);
        
        _service.Add(entity);
        _service.CommitAsync();
        
        return Ok();
    }

    [HttpPut]
    public virtual IActionResult Put( [FromForm] TDTO dto_model)
    {
        var entities = _service.Query().AsNoTrackingWithIdentityResolution();
        var entity = entities.FirstOrDefault(c => Equals(c.Id, dto_model.Id));

        if(entity == null)
            throw new NotImplementedException();
        
        _mapperToDto.Map(dto_model,entity);
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
            throw new NotImplementedException();
        
        _service.Remove(entity);
        _service.CommitAsync();
        
        return Ok();
    }
}