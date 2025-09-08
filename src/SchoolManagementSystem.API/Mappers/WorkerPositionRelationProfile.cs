
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.API.Mappers;

public class WorkerPositionRelationProfile : Profile
{
    public WorkerPositionRelationProfile()
    {
        CreateMap<WorkerPositionRelation, WorkerPositionRelationDto>();
        CreateMap<WorkerPositionRelationDto, WorkerPositionRelation>();
    }
}