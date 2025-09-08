
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecordController<TEntity, TDTO> : Controller where TEntity :  Record
{
    public readonly IRecordService<TEntity> _service;
    public readonly IMapper _mapperToDto;
    
    public RecordController(IRecordService<TEntity> service,
        IMapper mapperToDto)
    {
        _service = service;
        _mapperToDto = mapperToDto;
    }    

}
