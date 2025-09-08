
using AutoMapper;

namespace SchoolManagementSystem.API.Mappers;

public static class AutoMapperFactory
{
    public static IMapper CreateMapper()
    {
        var profiles = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.Namespace == "SchoolManagementSystem.API.Mappers")
            .Where(x => !x.ContainsGenericParameters)
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x.IsAssignableTo(typeof(Profile)))
            .ToList();
        return new MapperConfiguration(config =>
        {
            // config.AddProfile(new ClassroomProfile());
            foreach (var profile in profiles)
                config.AddProfile(profile);
        }).CreateMapper();
    }
}
