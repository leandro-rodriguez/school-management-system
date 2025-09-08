
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationEnumController : Controller 
{
    public EducationEnumController( 
        )
    {
    }

    [HttpGet]
    public virtual IActionResult GetAll()
    {
        return Ok(Enum.GetNames<Education>());
    }
}
