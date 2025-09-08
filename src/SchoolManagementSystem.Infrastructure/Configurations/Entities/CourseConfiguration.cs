
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        
        // builder.HasMany(c => c.Teachers)
        //         .WithMany(t => t.Courses)
        //         .UsingEntity<TeacherCourseRelation>(
        //             j => 
        //             {
        //                 j.Property(pt => pt.CorrespondingPorcentage);
        //                 j.HasKey(pt => new {pt.TeacherId, pt.CourseId});
        //             }
        //         );

        builder.HasMany(c => c.CourseGroups)
                .WithOne(c => c.Course);

        builder.Property(c => c.Name)
            .IsRequired();
        
        builder.Property(c => c.Type)
            .IsRequired();
        
        builder.Property(c => c.Price)
            .IsRequired();
    }
}
