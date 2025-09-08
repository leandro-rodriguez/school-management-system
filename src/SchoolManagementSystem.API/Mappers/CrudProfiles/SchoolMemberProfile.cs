
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class SchoolMemberProfile : Profile
{
    public SchoolMemberProfile()
    {
        CreateMap<SchoolMember, SchoolMemberDto>();
        CreateMap<SchoolMemberDto, SchoolMember>();
    }
}