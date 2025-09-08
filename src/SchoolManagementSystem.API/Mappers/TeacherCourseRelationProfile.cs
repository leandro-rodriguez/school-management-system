
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.API.Mappers;

public class TeacherCourseRelationProfile : Profile
{
    public TeacherCourseRelationProfile()
    {
        CreateMap<TeacherCourseRelation, TeacherCourseRelationDto>();
        CreateMap<TeacherCourseRelationDto, TeacherCourseRelation>();
    }
}