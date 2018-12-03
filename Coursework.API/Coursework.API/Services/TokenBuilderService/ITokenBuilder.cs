using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace Coursework.API.Services.TokenBuilderService
{
    public interface ITokenBuilder
    {
        Task<AuthenticationToken> BuildAsync(string email);
    }
}
