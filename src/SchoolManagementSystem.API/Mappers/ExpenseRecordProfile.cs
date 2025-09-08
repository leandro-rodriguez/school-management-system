
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.API.Mappers;

public class ExpenseRecordProfile : Profile
{
    public ExpenseRecordProfile()
    {
        CreateMap<ExpenseRecord, ExpenseRecordDto>();
        CreateMap<ExpenseDto, ExpenseRecord>();
    }
}