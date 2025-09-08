
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Application.Authenticate.Interfaces;

public interface IRoleManagerRepository
{
    Task<bool> RoleExists(string role);
    
    Task<IdentityResult> Create(IdentityRole role);
}
