
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class ClassroomProfile : Profile
{
    public ClassroomProfile()
    {
        CreateMap<Classroom, ClassroomDto>();
        CreateMap<ClassroomDto, Classroom>();
        // CreateMap<DevicePostModel, Device>();
        // CreateMap<DevicePutModel, Device>();
    }
}

// // using SchoolManagementSystem.API.Dtos;
// // using SchoolManagementSystem.Domain.Entities;

// // namespace SchoolManagementSystem.API.Mappers;

// // public class ClassroomMapper : IMapper<Classroom, ClassroomDto>
// // {
// //     Func<Classroom, ClassroomDto> IMapper<Classroom, ClassroomDto>.Mapper()
// //     {
// //         return delegate(Classroom classroom)
// //         {
// //             return new ClassroomDto
// //             {
// //                 Id = classroom.Id,
// //                 Name = classroom.Name,
// //                 Capacity = classroom.Capacity
// //             };
// //         };
// //     }
// // }