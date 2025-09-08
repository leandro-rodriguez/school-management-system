
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
public class ConsultWorkerSalaryController : Controller
{   
    IConsultWorkerSalaryService _service;
    public ConsultWorkerSalaryController(IConsultWorkerSalaryService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var worker = _service.Query().SingleOrDefault(c => c.Id == id);
        if( worker == null)
            return NotFound();

        var dto = new ConsultWorkerSalaryGetSingleDto
            {
                Id = id,
                WorkerName = worker.Name,
                InfoByDate = new List<InfoByDateDto>(),
            };
            
        foreach(var date in _service.GetAllPaymentDates(id))
            dto.InfoByDate.Add(
                    new InfoByDateDto{
                        Date = date,
                        InfoByPosition =  new List<InfoByPositionDto>(),
                        InfoByCourse = new List<InfoByCourseDto>()
                    });

        foreach(var info in dto.InfoByDate)
        {
            var _query = _service.GetWorkerFixSalariesByDate(id,info.Date);
            foreach (var row in _query)
            {
                info.InfoByPosition.Add(
                    new InfoByPositionDto{
                        Position = row.Position.Name,
                        PositionId = row.PositionId,
                        FixSalaryPosition = row.Payment
                    }
                );
            }
        }
        var tCGR_repo = _service.GetTeacherCourseGroupRelationRepo();
        var tCR_repo = _service.GetTeacherCourseRelationRepo();
        foreach (var info in dto.InfoByDate)
        {
            var _querytcr = tCR_repo.Query().Where(c => c.TeacherId == id).Include(c => c.Course);
            foreach (var row in _querytcr)
            {
                InfoByCourseDto course = new InfoByCourseDto()
                {
                    CourseId = row.CourseId,
                    CourseName = row.Course.Name,
                    Porcentage = row.CorrespondingPorcentage,
                    InfoByCourseGroup = new List<InfoByCourseGroupDto>()
                };
                var _querytcgr = tCGR_repo.Query().Where(c => c.TeacherId == id 
                                                            && c.CourseGroupCourseId == course.CourseId
                                                             && c.StartDate <= info.Date
                                                            && (c.EndDate >= info.Date || c.EndDate < c.StartDate))
                                                    .Include(c => c.CourseGroup.StudentCourseGroupRelations);
                foreach (var group in _querytcgr)
                {
                    var income = group.CourseGroup.StudentCourseGroupRelations.Where(c => c.StartDate <= info.Date && c.EndDate >= info.Date).Count() * row.Course.Price;
                    course.InfoByCourseGroup.Add(new InfoByCourseGroupDto()
                    {
                        CourseGroupId = group.CourseGroup.Id
                        ,
                        CourseGroupName = group.CourseGroup.Name
                        ,
                        CourseGroupIncome = income
                        ,
                        CourseGroupWorkerPayment = ((double)(1.0) / 100) * income * course.Porcentage
                    });
                }
                info.InfoByCourse.Add(course);
            }
        }
        return Ok(dto.InfoByDate);
    }
}
