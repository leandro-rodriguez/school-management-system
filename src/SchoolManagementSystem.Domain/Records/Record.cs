
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Records;

public abstract class Record
{
    // [Required]
    // [DataType(DataType.Date)]
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
    //     ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
}
