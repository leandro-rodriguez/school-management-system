using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Domain.Entities;

public class Teacher : Worker
{

    public IList<CourseGroup> CourseGroups { get; set; }
    // public IList<Course> Courses { get; set; }
    public IList<TeacherCourseGroupRelation> TeacherCourseGroupRelations { get; set; }
    public IList<TeacherCourseRelation> TeacherCourseRelations { get; set; }
}