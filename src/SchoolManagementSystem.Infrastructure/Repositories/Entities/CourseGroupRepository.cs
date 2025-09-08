using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class CourseGroupRepository : ActiveRepository<CourseGroup>, ICourseGroupRepository
{
    public CourseGroupRepository(IObjectContext context) : base(context)
    {

    }

    public CourseGroup GetById(string id)
    {
        return Query().Where(g => g.Id == id).FirstOrDefault();
    }
}