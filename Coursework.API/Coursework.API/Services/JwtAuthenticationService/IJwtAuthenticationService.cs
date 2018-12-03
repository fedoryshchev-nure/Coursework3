using Coursework.API.DTOs;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace Coursework.API.Services.AuthenticationService
{
    public interface IJwtAuthenticationService
    {
        Task RegisterAsync(UserDTO user);
        Task<AuthenticationToken> Authenticate(LoginModel user);
    }
}
