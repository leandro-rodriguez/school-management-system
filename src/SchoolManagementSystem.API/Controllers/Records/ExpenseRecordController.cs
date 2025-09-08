
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Controllers.Records;

public class ExpenseRecordController : RecordController<ExpenseRecord, ExpenseRecordDto>
{
    public ExpenseRecordController(IExpenseRecordService service,
        IMapper mapper) : base(service, mapper)
    {
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok
        (
            _service.Query()                
                .Include(e => e.Expense)
                .Select(_mapperToDto.Map<ExpenseRecord, ExpenseRecordDto>)
                .ToList()
        );
    }
}
