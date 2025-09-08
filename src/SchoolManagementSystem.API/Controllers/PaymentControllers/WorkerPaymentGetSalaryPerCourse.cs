
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
public class WorkerPaymentGetSalaryPerCourseController : Controller
{
    IDoWorkersPaymentService _service;
    IMapper mapper;
    public WorkerPaymentGetSalaryPerCourseController(IDoWorkersPaymentService service, IMapper mapper)
    {
        this.mapper = mapper;
        _service = service;
    }

    [HttpGet("{workerid}/{courseid}/{date}")]
    public IActionResult Get(string workerid, string courseid, string date)
    {
        System.Console.WriteLine(date);
        
        var Date = new DateTime(2020,03,01);

        try{

            Date = DateTime.Parse(date);
        }
        catch {};


        var worker = _service.Query().SingleOrDefault(c => c.Id == workerid);
        if (worker == null)
            NotFound();

        return Ok(_service.GetWorkerPaymentInfo(workerid, Date).InfoByDate[0]
                    .InfoByCourse
                    .Single(c => c.CourseId == courseid)
                    .InfoByCourseGroup
                    .Select(mapper.Map<InfoByCourseGroupDto>));
    }

}
