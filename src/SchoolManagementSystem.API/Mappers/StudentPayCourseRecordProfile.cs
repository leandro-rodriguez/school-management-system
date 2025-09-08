
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.API.Mappers;

public class StudentPayCourseRecordProfile : Profile
{
    public StudentPayCourseRecordProfile()
    {
        CreateMap<StudentPaymentRecordPerCourseGroup, StudentPayCourseRecordDto>();
        CreateMap<StudentPayCourseRecordDto, StudentPaymentRecordPerCourseGroup>();
    }
}