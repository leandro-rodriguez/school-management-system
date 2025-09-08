
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<Worker, WorkerDto>();
        CreateMap<WorkerDto, Worker>();
    }
}