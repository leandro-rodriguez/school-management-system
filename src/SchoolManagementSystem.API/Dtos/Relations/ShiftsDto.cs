

using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos
{
    public class ShiftsDto
    {
        public string ClassroomId { get; set; }
        
        public string Classroom { get; set; }
        
        public string ScheduleId { get; set; }
        
        public string ScheduleStartTime { get; set; }
        public string ScheduleEndTime { get; set; }

        public string Description {get; set; }
    }
}
