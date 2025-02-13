﻿using AutoMapper;
using Core.Constants;
using Core.DTO;
using Core.Entities.RefreshTokenEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Resources;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IOfferRoleService _offerRoleService;
        private readonly IUserService _userService;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        private readonly IEmailService _emailService;

        public AuthenticationService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IJwtService jwtService,
            IOfferRoleService offerRoleService,
            IUserService userService,
            IRepository<RefreshToken> refreshTokenRepository,
            IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwtService = jwtService;
            _offerRoleService = offerRoleService;
            _userService = userService;
            _refreshTokenRepository = refreshTokenRepository;
            _emailService = emailService;
        }

        public async Task RegisterAsync(UserRegistrationDTO userData, string callbackUrl)
        {
            var user = _mapper.Map<User>(userData);
            var createUserResult = await _userManager.CreateAsync(user, userData.Password);

            ExceptionMethods.CheckIdentityResult(createUserResult);

            var roleName = IdentityRoleNames.User.ToString();
            var userRole = await _roleManager.FindByNameAsync(roleName);

            ExceptionMethods.IdentityRoleNullCheck(userRole);

            var addToRoleResult = await _userManager.AddToRoleAsync(user, userRole.Name);

            ExceptionMethods.CheckIdentityResult(addToRoleResult);

            await _emailService.SendConfirmationEmailAsync(user, callbackUrl);
        }

        public async Task<UserAutorizationDTO> LoginAsync(UserLoginDTO data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, data.Password))
            {
                throw new HttpException(ErrorMessages.IncorrectLoginOrPassword, HttpStatusCode.Unauthorized);
            }

            var userRole = await _userService.GetUserRoleAsync(user);

            return await GenerateUserTokens(user, userRole);
        }

        public async Task LogoutAsync(UserLogoutDTO userLogoutDTO)
        {
            var refreshToken = await _refreshTokenRepository
                .GetBySpecAsync(new RefreshTokenSpecification.GetByToken(userLogoutDTO.RefreshToken));

            ExceptionMethods.RefreshTokenNullCheck(refreshToken);

            await _refreshTokenRepository.DeleteAsync(refreshToken);
        }

        private async Task<UserAutorizationDTO> GenerateUserTokens(User user, string userRole)
        {
            var claims = _jwtService.SetClaims(user, userRole);
            var accessToken = _jwtService.CreateToken(claims);
            var refreshToken = await CreateRefreshToken(user.Id);
            user.RefreshTokens.Add(refreshToken);

            var tokens = new UserAutorizationDTO()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return tokens;
        }

        private async Task<RefreshToken> CreateRefreshToken(string userId)
        {
            var refeshToken = _jwtService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refeshToken,
                UserId = userId
            };

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);

            return refreshTokenEntity;
        }

        public async Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO)
        {
            var refreshToken = await _refreshTokenRepository
                .GetBySpecAsync(new RefreshTokenSpecification.GetByToken(userTokensDTO.RefreshToken));

            ExceptionMethods.RefreshTokenNullCheck(refreshToken);

            var claims = _jwtService.GetClaimsFromExpiredToken(userTokensDTO.AccessToken);
            var newAccessToken = _jwtService.CreateToken(claims);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            refreshToken.Token = newRefreshToken;

            await _refreshTokenRepository.UpdateAsync(refreshToken);

            var tokens = new UserAutorizationDTO()
            {
                AccessToken = newAccessToken,
                RefreshToken = refreshToken.Token
            };

            return tokens;
        }
    }
}
