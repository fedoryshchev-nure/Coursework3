using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using Coursework.API.Options;
using Data.UnitOfWork;
using Microsoft.IdentityModel.Tokens;

namespace Coursework.API.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AuthenticationService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<string> Authenticate(LoginModel user)
        {
            var claims = await GetIdentityAsync(user.Email, user.Password);
            if (claims != null)
            {
                var token = BuildToken(claims);

                return token;
            }
            else
                throw new Exception("Invalid username or password.");
        }

        public async Task RegisterAsync(UserDTO user)
        {
            await unitOfWork.Users.AddAsync(mapper.Map<User>(user));

            await unitOfWork.CompleteAsync();
        }

        private string BuildToken(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var expires = now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME));
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

        private async Task<IEnumerable<Claim>> GetIdentityAsync(string email, string password)
        {
            var hashedPassword = password.GetHashCode().ToString();
            User user = await unitOfWork.Users.GetAsync(email, hashedPassword);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                };

                return claims;
            }

            return null;
        }
    }
}
