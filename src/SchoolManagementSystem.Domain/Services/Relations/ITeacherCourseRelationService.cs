

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface ITeacherCourseRelationService : IService<TeacherCourseRelation>
{
    public bool ValidateIds(string TeacherId, string CourseId);
}