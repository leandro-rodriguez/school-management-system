
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Interfaces;
 namespace SchoolManagementSystem.Domain.Entities;

public class Entity : Identifiable<string>
{
    public virtual string Id { get; set; } = Guid.NewGuid().ToString(); 
    public bool Active {get; set;} = true;

}