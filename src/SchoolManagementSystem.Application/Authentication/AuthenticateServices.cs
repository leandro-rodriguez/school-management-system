
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Application.Authenticate.Models;
using SchoolManagementSystem.Application.Authenticate.Interfaces;

namespace SchoolManagementSystem.Application.Authenticate;

public class AuthenticateServices : IAuthenticateService
{
    private readonly IUserManagerRepository _userManagerRepository;
    private readonly IRoleManagerRepository _roleManagerRepository;
    private readonly IConfiguration _configuration;

    public AuthenticateServices(
        IUserManagerRepository userManagerRepository,
        IRoleManagerRepository roleManagerRepository,
        IConfiguration configuration)
    {
        _userManagerRepository = userManagerRepository;
        _roleManagerRepository = roleManagerRepository;
        _configuration = configuration;
    }

    public async Task<Response<JwtSecurityToken>> Login(string userName, string password)
    {
        var user = await _userManagerRepository.FindByName(userName);
        
        if (user != null && await _userManagerRepository.CheckPassword(user, password))
        {
            var userRoles = await _userManagerRepository.GetRoles(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return new Response<JwtSecurityToken> { Result=GetToken(authClaims), Status="Successful", Message="User created successfully!"};
        }

        return new Response<JwtSecurityToken> {Result=null, Status="Error", Message="User and password do not match."};
    }

    public async Task<Response> Register(string userName, string email, string password)
    {
        var userExists = await _userManagerRepository.FindByName(userName);
        if (userExists != null)
            return new Response { Status = "Error", Message = "User already exists!" };

        IdentityUser user = new()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = userName
        };
        var result = await _userManagerRepository.Create(user, password);
        if (!result.Succeeded)
            return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." };

        return new Response { Status = "Successful", Message = "User created successfully!" };
    }

    public async Task<Response> RegisterAdmin(string userName, string email, string password)
    {
        var userExists = await _userManagerRepository.FindByName(userName);
        if (userExists != null)
            return new Response { Status = "Error", Message = "User already exists!" };

        IdentityUser user = new()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = userName
        };
        var result = await _userManagerRepository.Create(user, password);
        if (!result.Succeeded)
            return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." };

        if (!await _roleManagerRepository.RoleExists(UserRoles.Admin))
            await _roleManagerRepository.Create(new IdentityRole(UserRoles.Admin));
        if (!await _roleManagerRepository.RoleExists(UserRoles.User))
            await _roleManagerRepository.Create(new IdentityRole(UserRoles.User));

        if (await _roleManagerRepository.RoleExists(UserRoles.Admin))
        {
            await _userManagerRepository.AddToRole(user, UserRoles.Admin);
        }
        if (await _roleManagerRepository.RoleExists(UserRoles.User))
        {
            await _userManagerRepository.AddToRole(user, UserRoles.User);
        }

        return new Response { Status = "Successful", Message = "User created successfully!" };
    }

    public async Task<Response> RegisterSecretary(string userName, string email, string password)
    {
        var userExists = await _userManagerRepository.FindByName(userName);
        if (userExists != null)
            return new Response { Status = "Error", Message = "User already exists!" };

        IdentityUser user = new()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = userName
        };
        var result = await _userManagerRepository.Create(user, password);
        if (!result.Succeeded)
            return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." };

        if (!await _roleManagerRepository.RoleExists(UserRoles.Secretary))
            await _roleManagerRepository.Create(new IdentityRole(UserRoles.Secretary));
        if (!await _roleManagerRepository.RoleExists(UserRoles.User))
            await _roleManagerRepository.Create(new IdentityRole(UserRoles.User));

        if (await _roleManagerRepository.RoleExists(UserRoles.Secretary))
            await _userManagerRepository.AddToRole(user, UserRoles.Secretary);
        if (await _roleManagerRepository.RoleExists(UserRoles.User))
            await _userManagerRepository.AddToRole(user, UserRoles.User);

        return new Response { Status = "Successful", Message = "User created successfully!" };
    }


    public async Task<Response> GeneratePasswordResetToken(string username)
    {
        var user = await _userManagerRepository.FindByName(username);

        if (user == null)
            return new Response { Status="Error", Message="User do not exist." };

        var token = await _userManagerRepository.GeneratePasswordResetToken(user);

        return new Response { Result=token, Status="Successful", Message="Token created successfully!"};
    }

    public async Task<Response> ChangePassword(string username, string currentPassword, string newPassword)
    {
        var user = await _userManagerRepository.FindByName(username);

        if (user == null)
            return new Response { Status="Error", Message="User do not exist." };

        if (! await _userManagerRepository.CheckPassword(user, currentPassword))
            return new Response { Status="Error", Message="User and password do not match." };

        if (! await _userManagerRepository.IsValidPassword(user, newPassword))
            return new Response { Status="Error", Message="New password is invalid." };

        await _userManagerRepository.ChangePassword(user, currentPassword, newPassword);

        return new Response { Status="Successful", Message="Password changed successfully!" };
    }

    public async Task<Response> CreateRole(string role)
    {
        if (! await _roleManagerRepository.RoleExists(role))
        {
            var newRole = new IdentityRole
            {
                Name = role,
                NormalizedName = role.ToUpper()
            };

            if ((await _roleManagerRepository.Create(newRole)).Succeeded)
            {
                return new Response { Status="Successful", Message="Role added successfully!" };
            }
        }

        return new Response { Status="Error", Message="Something was wrong." };
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
