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
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Coursework.API.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AuthenticationService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AuthenticationToken> Authenticate(LoginModel model, IEnumerable<Claim> claims)
        {
            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var token = BuildToken(claims);

                return new AuthenticationToken { Value = token };
            }
            else
                throw new Exception("Invalid username or password.");
        }

        private string BuildToken(IEnumerable<Claim> claims)
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

        public async Task RegisterAsync(UserDTO dto)
        {
            var user = mapper.Map<User>(dto);
            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                AddAllClaimsToUserAsync(user);
                AddAllRolesToUserAsync(user);
            }
            else
                throw new Exception("Registration failed");
        }

        private async Task AddAllClaimsToUserAsync(User user)
        {
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
        }

        private async Task AddAllRolesToUserAsync(User user)
        {
            await userManager.AddToRoleAsync(user, "User");
        }


    }
}
