using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
{
    public void Configure(EntityTypeBuilder<CourseGroup> builder)
    {
        builder.HasKey(p => new { p.Id, p.CourseId });

        builder.HasOne(cg => cg.Course)
            .WithMany(t => t.CourseGroups);

        // builder.HasOne(w => w.Teacher)
        // .WithMany(p => p.CourseGroups).UsingEntity<TeacherCourseGroupRelation>(
        //     j =>
        //     {
        //         j.Property(pt => pt.EndDate);
        //         j.HasKey(t => new { t.CourseGroupId, t.CourseGroupCourseId, t.StartDate });
        //     });

        builder.HasOne(cg => cg.Teacher)
            .WithMany(t => t.CourseGroups)
            .OnDelete(DeleteBehavior.SetNull);
        
        
        builder.Property(cg => cg.Name)
            .IsRequired();

        builder.Property(cg => cg.Capacity)
            .IsRequired();
        
        builder.Property(cg => cg.StartDate)
            .IsRequired();
        
        builder.Property(cg => cg.EndDate);

    }
}