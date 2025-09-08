using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        // builder.HasBaseType<Expense>();
        
        builder.Property(expense => expense.Id)
            .IsRequired();
        builder.HasKey(p => p.Id);

        builder.Property(expense => expense.Category)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(expense => expense.Description)
            .IsRequired()
            .HasMaxLength(100);
    }
}