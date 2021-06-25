using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync(
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(
            [FromRoute]Guid userId,
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserAsync(userId,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(
            AddUserCommand addUserCommand,
            CancellationToken cancellationToken)
        {
            await _userService.AddUserAsync(addUserCommand,cancellationToken);
            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(
            [FromRoute] Guid userId,
            [FromBody] UpdateUserCommand updateUserCommand,
            CancellationToken cancellationToken)
        {
            updateUserCommand.UserId = userId;

            await _userService.UpdateUserAsync(updateUserCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(userId, cancellationToken);
            return Ok();
        }
    }
}
