
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.API.Mappers;

public class StudentCourseGroupRelationProfile : Profile
{
    public StudentCourseGroupRelationProfile()
    {
        CreateMap<StudentCourseGroupRelation, StudentCourseGroupRelationDto>();
        CreateMap<StudentCourseGroupRelationDto, StudentCourseGroupRelation>();
    }
}