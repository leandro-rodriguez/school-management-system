
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class TuitorProfile : Profile
{
    public TuitorProfile()
    {
        CreateMap<Tuitor, TuitorDto>();
        CreateMap<TuitorDto, Tuitor>();
    }
}