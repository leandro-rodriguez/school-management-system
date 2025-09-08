using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        // builder.ToTable("Workers");
        
        builder.HasBaseType<SchoolMember>();

        // builder.HasDiscriminator<bool>(c => c.IsTeacher)
        //     .HasValue<Teacher>(true)
        //     ;

        builder.HasMany(w => w.Services)
            .WithMany(r => r.Providers);
        
        builder.HasMany(w => w.Positions)
            .WithMany(p => p.Workers).UsingEntity<WorkerPositionRelation>(
                j =>
                {
                    j.Property(pt => pt.FixedSalary);
                    j.HasKey(t => new { t.WorkerId, t.PositionId, t.StartDate});
                });
    }
}