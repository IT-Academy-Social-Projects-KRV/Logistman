﻿using Core.DTO;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomService
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(UserRegistrationDTO data);
        Task<UserAutorizationDTO> LoginAsync(UserLoginDTO data);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserLogoutDTO userLogoutDTO);
    }
}
