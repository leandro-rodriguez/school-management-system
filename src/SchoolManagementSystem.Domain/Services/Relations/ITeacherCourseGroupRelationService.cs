

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface ITeacherCourseGroupRelationService : IService<TeacherCourseGroupRelation>
{
    public bool ValidateIds(string TeacherId, string CourseGroupId, string CourseId);
    public void AddTeacherCourseRelation(TeacherCourseRelation item);
}