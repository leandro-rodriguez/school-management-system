
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class SchoolMemberDto : IDto
{
        [Required]
        [StringLength(11)]
        public string IDCardNo { get; set; }

        [Required]
        [JsonPropertyName("key")]
        public string Id {get; set;}

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        
        // [Required]
        public int PhoneNumber{ get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        
        [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        [Display(Name = "Date Becomed Member")]
        public string DateBecomedMember { get; set; }
}
