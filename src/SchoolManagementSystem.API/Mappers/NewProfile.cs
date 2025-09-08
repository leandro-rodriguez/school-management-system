
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.API.Mappers;

public class NewProfile : Profile
{
    public NewProfile()
    {
        CreateMap<TeacherCourseRelationDto, TeacherCourseGroupRelationDto>();
        CreateMap<TeacherCourseGroupRelationDto, TeacherCourseRelationDto>();
    }
}