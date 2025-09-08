

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface IStudentCourseGroupRelationService : IService<StudentCourseGroupRelation>
{
    public bool ValidateIds(string StudentId, string courseGroupId, string courseId);
}