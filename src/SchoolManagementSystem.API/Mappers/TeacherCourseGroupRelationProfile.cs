
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.API.Mappers;

public class TeacherCourseGroupRelationProfile : Profile
{
    public TeacherCourseGroupRelationProfile()
    {
        CreateMap<TeacherCourseGroupRelation, TeacherCourseGroupRelationDto>();
        CreateMap<TeacherCourseGroupRelationDto, TeacherCourseGroupRelation>();
    }
}