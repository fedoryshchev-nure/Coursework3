using Coursework.API.DTOs;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Coursework.API.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(UserDTO user);
        Task<AuthenticationToken> Authenticate(LoginModel user, IEnumerable<Claim> claims);
    }
}
