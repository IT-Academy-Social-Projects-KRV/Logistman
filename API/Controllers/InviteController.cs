﻿using Core.Constants;
using Core.DTO.InviteDTO;
using Core.Helpers;
using Core.Interfaces.CustomService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        private readonly IInviteService _inviteService;
        private readonly IUserService _userService;

        public InvitesController(
            IInviteService inviteService,
            IUserService userService)
        {
            _inviteService = inviteService;
            _userService = userService;
        }

        [HttpPost("manage-list")]
        [AuthorizeByRole(IdentityRoleNames.Logist)]
        public async Task<IActionResult> ManageTripInvitesAsync(
            [FromBody] CreateTripInvitesDTO createTripInvitesDTO)
        {
            await _inviteService.ManageTripInvitesAsync(createTripInvitesDTO);
            return Ok();
        }

        [HttpPost("manage")]
        [AuthorizeByRole(IdentityRoleNames.User)]
        public async Task<IActionResult> ManageInviteAsync(
            [FromBody] ManageInviteDTO manageInviteDTO)
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            await _inviteService.ManageAsync(manageInviteDTO, userId);

            return Ok();
        }

        [HttpGet("offers")]
        [AuthorizeByRole(IdentityRoleNames.User)]
        public async Task<IActionResult> OffersInvitesAsync()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            var invites = await _inviteService.OffersInvitesAsync(userId);

            return Ok(invites);
        }
    }
}
