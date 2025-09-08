
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations;

public class TeacherCourseRelation
{
    public string TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public int CorrespondingPorcentage { get; set; }
}
