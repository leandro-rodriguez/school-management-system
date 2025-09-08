using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class SchoolMemberConfiguration : IEntityTypeConfiguration<SchoolMember>
{
    public void Configure(EntityTypeBuilder<SchoolMember> builder)
    {

        builder.HasDiscriminator(c => c.Type)
            .HasValue<Student>("Student")
            .HasValue<NonTeacherWorker>( "NTWorker")
            .HasValue<Teacher>( "Teacher")
            // .HasValue<Teacher>("Teacher");
            ;
       


        builder.Property(s => s.Id)
            .IsRequired();
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired();

        builder.Property(s => s.LastName)
            .IsRequired();

        builder.Property(s => s.PhoneNumber)
            .IsRequired();

        builder.Property(s => s.Address)
            .IsRequired();

        builder.Property(s => s.DateBecomedMember)
            .IsRequired();
    }
}
