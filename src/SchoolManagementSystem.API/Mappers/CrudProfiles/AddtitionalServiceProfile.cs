
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class AdditionalServiceProfile : Profile
{
    public AdditionalServiceProfile()
    {
        CreateMap<AdditionalService, AdditionalServiceDto>();
        CreateMap<AdditionalServiceDto, AdditionalService>();
    }
}