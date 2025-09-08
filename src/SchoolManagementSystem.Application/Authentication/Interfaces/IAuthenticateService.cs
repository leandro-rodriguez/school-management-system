
using System.IdentityModel.Tokens.Jwt;
using SchoolManagementSystem.Application.Authenticate.Models;

namespace SchoolManagementSystem.Application.Authenticate.Interfaces;

public interface IAuthenticateService
{
    Task<Response<JwtSecurityToken>> Login(string userName, string password);

    Task<Response> Register(string userName, string email, string password);

    Task<Response> RegisterAdmin(string userName, string email, string password);

    Task<Response> RegisterSecretary(string userName, string email, string password);
    
    Task<Response> CreateRole(string role);
}
