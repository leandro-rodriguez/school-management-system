
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class TeacherCourseGroupRelationConfiguration : IEntityTypeConfiguration<TeacherCourseGroupRelation>
{
    public void Configure(EntityTypeBuilder<TeacherCourseGroupRelation> builder)
    {
        builder.HasKey(t 
            => new { t.TeacherId, t.CourseGroupId, t.CourseGroupCourseId, t.StartDate });
    }
}
