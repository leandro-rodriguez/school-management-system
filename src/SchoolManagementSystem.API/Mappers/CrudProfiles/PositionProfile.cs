
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class PositionProfile : Profile
{
    public PositionProfile()
    {
        CreateMap<Position, PositionDto>();
        CreateMap<PositionDto, Position>();
    }
}