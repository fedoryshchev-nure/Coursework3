﻿using Coursework.API.DTOs;
using System.Threading.Tasks;

namespace Coursework.API.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(UserDTO user);
        Task<string> Authenticate(LoginModel user);
    }
}
