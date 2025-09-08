using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class TeacherRepository : ActiveRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(IObjectContext context) : base(context)
    {

    }

    public void SpecialPost(string id)
    {
        // var context = (Context as SchoolContext);
        // var member = context.SchoolMembers.(id);
        // member.
    }
}