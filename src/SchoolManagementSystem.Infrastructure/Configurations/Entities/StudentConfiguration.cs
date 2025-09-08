using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // builder.ToTable("Students");
        
        builder.HasBaseType<SchoolMember>();
        
        // builder.Property(s => s.Founds)
        //     .IsRequired();

        // builder.Property(s => s.ScholarityLevel)
        //     .IsRequired();

        builder.HasOne(s => s.Tuitor)
            .WithMany(t => t.Students);
    }
}