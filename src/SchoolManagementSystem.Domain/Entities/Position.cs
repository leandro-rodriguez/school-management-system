
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Domain.Entities;

public class Position : Entity
{
    // [Required]
    // [MaxLength(20)]
    public string Name { get; set; }

    // [Required]
    public IList<Worker> Workers { get; set; }
    public IList<WorkerPositionRelation> WorkerPositionRelations { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
