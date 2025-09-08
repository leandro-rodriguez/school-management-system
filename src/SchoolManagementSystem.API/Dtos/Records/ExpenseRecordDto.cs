
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class ExpenseRecordDto
{
    public string ExpenseId { get; set; }
    public string ExpenseCategory { get; set; }

    // [Required]
    // [MaxLength(100)]
    public string ExpenseDescription { get; set; }

    // [Required]
    // [Range(1,99999)]
    public int Amount { get; set; }

    // [Required]
    // [Range(0.01,99999)]
    // [DataType(DataType.Currency)]
    // [Column(TypeName = "money")]
    public double Value { get; set; }


}
