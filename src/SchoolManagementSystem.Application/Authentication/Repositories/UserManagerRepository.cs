
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.Authenticate.Interfaces;

namespace SchoolManagementSystem.Application.Authenticate.Repositories;

public class UserManagerRepository : IUserManagerRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserManagerRepository(UserManager<IdentityUser> userManager)
        => _userManager = userManager;

    public async Task<IdentityResult> AddToRole(IdentityUser user, string role)
        => await _userManager.AddToRoleAsync(user,role);

    public async Task<bool> CheckPassword(IdentityUser user, string password)
        => await _userManager.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> Create(IdentityUser user, string password)
        => await _userManager.CreateAsync(user, password);

    public async Task<IdentityUser> FindByName(string username)
        => await _userManager.FindByNameAsync(username);

    public async Task<IList<string>> GetRoles(IdentityUser user)
        => await _userManager.GetRolesAsync(user);

    public async Task<string> GeneratePasswordResetToken(IdentityUser user)
        => await _userManager.GeneratePasswordResetTokenAsync(user);

    public async Task<IdentityResult> ChangePassword(IdentityUser user, 
        string currentPassword, string newPassword) 
            => await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

    public async Task<bool> IsValidPassword(IdentityUser user, string password)
    {
        var validators = _userManager.PasswordValidators;

        foreach (var item in validators)
        {
            var validation = await item.ValidateAsync(_userManager, user, password);

            if (validation.Errors.Any())
                return false; 
        }

        return true;
    }
}