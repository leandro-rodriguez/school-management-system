using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class TeacherPayRecordPerCourseConfiguration 
    : IEntityTypeConfiguration<TeacherPayRecordPerCourse>
{
    public void Configure(EntityTypeBuilder<TeacherPayRecordPerCourse> builder)
    {
        builder.HasKey(w => new { w.CourseId, w.TeacherId, w.Date });
    }
}