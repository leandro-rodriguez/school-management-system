
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class BasicMeanProfile : Profile
{
    public BasicMeanProfile()
    {
        CreateMap<BasicMean, BasicMeanDto>();
        CreateMap<BasicMeanDto, BasicMean>();
    }
}