
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers.Records;

[Route("api/[controller]")]
public class WorkerPaymentGetFixSalaryController : Controller
{
    IDoWorkersPaymentService _service;
    IMapper mapper;
    public WorkerPaymentGetFixSalaryController(IDoWorkersPaymentService service, IMapper mapper)
    {
        this.mapper = mapper;
        _service = service;
    }

    [HttpGet("{id}/{date}")]
    public IActionResult Get(string id,string date)
    {
        var Date = DateTime.Now;
        try{

            Date = DateTime.Parse(date);
        }
        catch{};

        var worker = _service.Query().SingleOrDefault(c => c.Id == id);
        if (worker == null)
            NotFound();

        return Ok(_service.GetWorkerPaymentInfo(id, Date).InfoByDate[0].InfoByPosition.Select(mapper.Map<InfoByPositionDto>));
    }

}
