
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.API.Mappers;

public class ConsultWorkerSalaryProfile : Profile
{
    public ConsultWorkerSalaryProfile()
    {
        CreateMap<ConsultWorkerSalaryGetSingleDto, WorkerPaymentInfo>();
        CreateMap<WorkerPaymentInfo, ConsultWorkerSalaryGetSingleDto>();
        
        CreateMap<InfoByDateDto, InfoByDate>();
        CreateMap<InfoByDate, InfoByDateDto>();
        
        CreateMap<InfoByCourseDto, InfoByCourse>();
        CreateMap<InfoByCourse, InfoByCourseDto>();

        CreateMap<InfoByCourseGroupDto, InfoByCourseGroup>();
        CreateMap<InfoByCourseGroup, InfoByCourseGroupDto>();

        CreateMap<InfoByPositionDto, InfoByPosition>();
        CreateMap<InfoByPosition, InfoByPositionDto>();

    }
}