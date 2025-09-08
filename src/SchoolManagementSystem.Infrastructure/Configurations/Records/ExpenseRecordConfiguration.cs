
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class ExpenseRecordConfiguration : IEntityTypeConfiguration<ExpenseRecord>
{
    public void Configure(EntityTypeBuilder<ExpenseRecord> builder)
    {
        builder.HasKey(e => new { e.ExpenseId, e.Date });

        builder.Property(e => e.Value);
        
        builder.Property(e => e.Amount);
    }
}
