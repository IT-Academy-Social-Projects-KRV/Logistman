﻿using Core.Interfaces.CustomService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Core.Constants;
using Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-info")]
        public async Task<ActionResult> GetUserInfo()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            var userInfo = await _userService.GetUserProfileInfoAsync(userId);
            return Ok(userInfo);
        }

        [HttpPost("edit-info")]
        public async Task<ActionResult> UserEditProfileInfo(UserEditProfileInfoDTO userEditProfileInfo)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            await _userService.UserEditProfileInfoAsync(userEditProfileInfo, userId, callbackUrl);
            return Ok();
        }

        [HttpPost("user-edit-info")]
        [AuthorizeByRole(IdentityRoleNames.Logist)]
        public async Task<ActionResult> UserEditProfileInfoAsync(UserEditProfileInfoDTO userEditProfileInfo, string email)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            var userId = await _userService.GetUserIdByEmailAsync(email);
            await _userService.UserEditProfileInfoAsync(userEditProfileInfo, userId, callbackUrl);
            return Ok();
        }

        [HttpGet("user-full-name")]
        public async Task<ActionResult<UserFullNameDTO>> GetUserFullName()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);

            return Ok(await _userService.GetUserFullNameAsync(userId));
        }

        [HttpGet]
        [AuthorizeByRole(IdentityRoleNames.Logist, IdentityRoleNames.Admin)]
        public async Task<ActionResult> GetAllUsersAsync([FromQuery] PaginationFilterDTO paginationFilter)
        {
            return Ok(await _userService.GetAllUsersAsync(paginationFilter));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserAsync()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);

            await _userService.DeleteUserAsync(userId);

            return Ok();
        }
    }
}
