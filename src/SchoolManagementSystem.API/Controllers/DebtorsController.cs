
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using System.Collections.Generic;
using System.Collections;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DebtorsController : Controller
{    
    public readonly IDoStudentPaymentService _servicePayment;
    public readonly IMapper mapper;

    public DebtorsController(IDoStudentPaymentService servicePayment,
        IMapper mapper)
    {
        _servicePayment = servicePayment;
        this.mapper = mapper;
    }    

    [HttpGet]
    public IActionResult GetAll()
    {
        List<DebtorDto> debtors = new List<DebtorDto>();
        foreach (Student student in _servicePayment.GetStudentRepo().Query())
        {
            var a = from debt in GroupCurseNoPaid(_servicePayment, student.Id)
                    where DateTime.Now.Date > debt.DatePaid.Date
                    group debt by debt.StudentId into g
                    select new DebtorDto
                    {
                        GroupId = g.First().GroupId,
                        GroupName = g.First().GroupName,
                        IDCardNo = student.IDCardNo,
                        StudentId = student.Id,
                        StudentName = student.Name,
                        StudentLastName = student.LastName,
                        Debt = g.Sum(s => s.CoursePrice),
                        Dealy = (DateTime.Now.Date - g.Min(s => s.DatePaid).Date).Days
                    };
            debtors.AddRange(a);
        }
        return Ok(debtors);        
    }

    [HttpGet("{id}")]
    public IActionResult GetDebtById(string id)
    {
        return Ok(GroupCurseNoPaid(_servicePayment, id)
                    .Select(r => new
                    {
                        GroupId = r.GroupId,
                        GroupName = r.GroupName,                        
                        Debt = r.CoursePrice,
                        Delay = (DateTime.Now.Date - r.DatePaid.Date).Days
                    }));
    }


    public static IQueryable<StudentGroupPaymentDto> GroupCurseNoPaid(IDoStudentPaymentService servicePayment, string studentId) 
    {
        IDoStudentPaymentService _servicePayment = servicePayment;
        // cursos-grupo que ya ha ido pagando el estudiante
        var q1 = from record in _servicePayment.GetStudentPaymentRecordPerCourseGroupRepo().Query()
                 where record.StudentId == studentId
                 select record.CourseGroupId;
        var l1 = q1.ToList();
        // cursos-grupo en los que no ha pagado a�n
        // solo tiene los que nunca ha pagado ni una vez
        var q2 = from relation in _servicePayment.GetStudentCourseGroupRelationRepo().Query()
                 where relation.StudentId == studentId
                 where !q1.Contains(relation.CourseGroupId)
                 select new StudentGroupPaymentDto
                 {
                     StudentId = relation.StudentId,
                     GroupId = relation.CourseGroupId,
                     GroupName = relation.CourseGroup.Name,
                     CourseId = relation.CourseGroupCourseId,
                     CoursePrice = relation.CourseGroup.Course.Price,
                     DatePaid = relation.CourseGroup.StartDate,
                     EndDate = relation.CourseGroup.EndDate,
                     Date = relation.StartDate,
                 };
        var l2 = q2.ToList();
        // de los registros de pago del estudiante determinado y su grupo de clase
        // agrupar los registros por el grupo de clase
        // tomando la �ltima fecha de pago, y el �ltimo mes pagado
        var q3 = from record in _servicePayment.GetStudentPaymentRecordPerCourseGroupRepo().Query()
                 where record.StudentId == studentId
                 group record by record.CourseGroupId into g
                 select new
                 {
                     StudentId = g.Select(r => r.StudentId).FirstOrDefault(),
                     CourseGroupId = g.Select(r => r.CourseGroupId).FirstOrDefault(),
                     CourseGroupName = g.Select(r => r.CourseGroup.Name).FirstOrDefault(),
                     CourseGroupCourseId = g.Select(r => r.CourseGroupCourseId).FirstOrDefault(),
                     DatePaid = g.Max(r => r.DatePaid),
                     Date = g.Max(r => r.Date),
                 };
        var l3 = q3.ToList();
        // haciendo un JOIN de la tabla anterior con la tabla de Relaciones
        // para obtener la fecha de fin
        var q4 = from record in q3
                 join relation in _servicePayment.GetStudentCourseGroupRelationRepo().Query()
                 on new
                 {
                     record.StudentId,
                     record.CourseGroupId,
                     record.CourseGroupCourseId,
                 } equals new
                 {
                     relation.StudentId,
                     relation.CourseGroupId,
                     relation.CourseGroupCourseId,
                 }
                 select new StudentGroupPaymentDto
                 {
                     StudentId = record.StudentId,
                     GroupId = record.CourseGroupId,
                     GroupName = record.CourseGroupName,
                     CourseId = record.CourseGroupCourseId,
                     CoursePrice = relation.CourseGroup.Course.Price,
                     DatePaid = record.DatePaid,
                     EndDate = relation.EndDate,
                     Date = record.Date,
                 };
        var l4 = q4.ToList();
        // Tomando solo los pagos pendientes
        var q5 = from r in q4
                 where r.DatePaid.Date < r.EndDate.Date
                 select r;
        var l5 = q5.ToList();
        // Se retorna los cursos que nunca se han pagado
        // junto a los cursos que se pagaron al menos una vez
        return q2.Union(q5);
    }
}
