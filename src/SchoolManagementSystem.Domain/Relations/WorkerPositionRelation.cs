
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations;

public class WorkerPositionRelation
{
    public string WorkerId { get; set; }
    public Worker Worker { get; set; }
    public string PositionId { get; set; }
    public Position Position { get; set; }
    public DateTime StartDate{get; set;}
    public DateTime EndDate{get; set;} = DateTime.MaxValue;
    public int FixedSalary { get; set; }
}
