using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class StudentCourseGroupRelationConfiguration : IEntityTypeConfiguration<StudentCourseGroupRelation>
{
    public void Configure(EntityTypeBuilder<StudentCourseGroupRelation> builder)
    {
        builder.HasKey(s 
            => new { s.StudentId, s.CourseGroupId, s.CourseGroupCourseId, s.StartDate });
    }
}