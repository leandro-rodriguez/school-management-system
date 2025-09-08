using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Name)
            .IsRequired();
        
        builder.Property(r => r.Category)
            .IsRequired();
        
        builder.Property(r => r.Price)
            .IsRequired();

        builder.HasMany(r => r.Providers)
            .WithMany(w => w.Services);
    }
}