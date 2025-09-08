
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.Authenticate.Interfaces;

namespace SchoolManagementSystem.Application.Authenticate.Repositories;

public class RoleManagerRepository : IRoleManagerRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagerRepository(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> Create(IdentityRole role)
        => await _roleManager.CreateAsync(role);

    public async Task<bool> RoleExists(string roleName)
        => await _roleManager.RoleExistsAsync(roleName);
}
