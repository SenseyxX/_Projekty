using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Contracts.Commands;
using Warehouse.Application.Dtos;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class UserController : Controller
    {
        private readonly UserHandler _userHandler;

        public UserController(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync(
            CancellationToken cancellationToken)
        {
            var result = await _userHandler.GetUsersAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(
            CreateUserCommand addUserCommand,
            CancellationToken cancellationToken)
        {
            await _userHandler.CreateUserAsync(addUserCommand,cancellationToken);
            return Ok();
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(
            [FromRoute]Guid userId,
            CancellationToken cancellationToken)
        {
            var result = await _userHandler.GetUserAsync(userId,cancellationToken);
            return Ok(result);
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUserAsync(
            [FromRoute] Guid userId,
            [FromBody] UpdateUserCommand updateUserCommand,
            CancellationToken cancellationToken)
        {
            updateUserCommand.UserId = userId;

            await _userHandler.UpdateUserAsync(updateUserCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUserAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken)
        {
            await _userHandler.DeleteUserAsync(userId, cancellationToken);
            return Ok();
        }
    }
}
