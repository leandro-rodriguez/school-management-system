
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Classroom : Entity
{
    public string Name {get; set;}

    public int Capacity { get; set; }
    
    public IList<Shift> Shifts { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
