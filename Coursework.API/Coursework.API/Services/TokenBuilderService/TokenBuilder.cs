using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Models.Origin;
using Coursework.API.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Coursework.API.Services.TokenBuilderService
{
    public class TokenBuilder : ITokenBuilder
    {
        private string email;
        private readonly UserManager<User> userManager;

        public TokenBuilder(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AuthenticationToken> BuildAsync(string email)
        {
            this.email = email;

            var claims = await GetClaimsAsync();
            var token = GetToken(claims);

            return new AuthenticationToken { Value = token };
        }

        private string GetToken(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var expires = now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME_DAYS));
            var signedKey = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: expires,
                    signingCredentials: signedKey);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }

        private async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            var roleClaim = await GetRoleAsClaimAsync();
            var emailClaim = new Claim(ClaimTypes.Email, email);

            return await Task.FromResult(
                new List<Claim>() { emailClaim, roleClaim });
        }

        private async Task<Claim> GetRoleAsClaimAsync()
        {
            var user = await userManager.FindByEmailAsync(email);
            var role = (await userManager.GetRolesAsync(user))
                .First();

            return await Task.FromResult(
                new Claim(ClaimTypes.Role, role));
        }
    }
}
