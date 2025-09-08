using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class TuitorConfiguration : IEntityTypeConfiguration<Tuitor>
{
    public void Configure(EntityTypeBuilder<Tuitor> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired();
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired();

        builder.Property(t => t.PhoneNumber)
            .IsRequired();
    }
}