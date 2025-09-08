using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        // builder.ToTable("Teachers");
        
        builder.HasBaseType<Worker>();

        builder.HasMany<CourseGroup>(t => t.CourseGroups)
            .WithOne(cg => cg.Teacher);
    }
}