
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<Shift, ShiftDto>();
        CreateMap<ShiftDto, Shift>();
        CreateMap<Shift, ShiftsDto>();
        CreateMap<ShiftsDto, Shift>();
    }
}