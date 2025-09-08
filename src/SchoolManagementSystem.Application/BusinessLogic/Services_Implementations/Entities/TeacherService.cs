
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class TeacherService : ActiveService<Teacher>, ITeacherService
{
    ISchoolMemberRepository schl_member_repo;
    public TeacherService(ISchoolMemberRepository schl_member_repo, ITeacherRepository repository) : base(repository)
    {
        this.schl_member_repo = schl_member_repo;
    }

    public Teacher GetTeacherById(string id)
    {
        return Query()
            .Where(teacher => teacher.Id == id)
            .Include(teacher => teacher.Services)
            .Include(teacher => teacher.AdditionalServices)
            .Include(teacher => teacher.CourseGroups)
            .Include(teacher => teacher.TeacherCourseRelations)
            .Include(teacher => teacher.TeacherCourseGroupRelations)
            .FirstOrDefault();
    }
    public bool BecomeTeacher(string id){
        var worker = schl_member_repo.Query().Single(c => c.Id == id);
        if (worker == null)
            return false;
        schl_member_repo.Update(worker);
        worker.Type = "Teacher";
        schl_member_repo.Commit();
        return true;
    }
}