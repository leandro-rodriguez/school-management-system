using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class BasicMeanConfiguration : IEntityTypeConfiguration<BasicMean>
{
    public void Configure(EntityTypeBuilder<BasicMean> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(p => p.Origin)
            .IsRequired()
            .HasMaxLength(30);
        
        builder.Property(p => p.InaugurationDate)
            .IsRequired()
            .HasColumnType("Date");
        
        builder.Property(p => p.DevaluationInTime)
            .IsRequired();
        
        builder.Property(p => p.Price)
            .IsRequired()
            .IsConcurrencyToken(true);
    }
}