using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Contracts.Commands.User;
using Warehouse.Application.Dtos.Item;
using Warehouse.Application.Dtos.User;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class UserController : Controller
    {
        private readonly UserHandler _userHandler;

        public UserController(UserHandler userHandler, RentalHandler rentalHandler)
        {
            _userHandler = userHandler;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync(
            CancellationToken cancellationToken)
        {
            var result = await _userHandler.GetUsersAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{userId:guid}/items")]
        [Authorize]
        public async Task<ActionResult<ItemDto>> GetUserItemsAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken)
        {
            var result = await _userHandler.GetUserItemsAsync(userId, cancellationToken);
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
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUserAsync(
            [FromRoute]Guid userId,
            CancellationToken cancellationToken)
        {
            var result = await _userHandler.GetUserAsync(userId,cancellationToken);
            return Ok(result);
        }
        
        [HttpPut("{userId:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync(
            [FromRoute] Guid userId,
            [FromBody] UpdateUserCommand updateUserCommand,
            CancellationToken cancellationToken)
        {
            updateUserCommand.UserId = userId;

            await _userHandler.UpdateUserAsync(updateUserCommand, cancellationToken);
            return Ok();
        }
        
        [HttpPut("{userId:guid}/password")]
        [Authorize]
        public async Task<IActionResult> UpdateUserPasswordAsync(
            [FromRoute] Guid userId,
            [FromBody] UpdateUserPasswordCommand updateUserPasswordCommand,
            CancellationToken cancellationToken)
        {
            updateUserPasswordCommand.UserId = userId;
            await _userHandler.UpdateUserPasswordAsync(updateUserPasswordCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{userId:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken)
        {
            await _userHandler.DeleteUserAsync(userId, cancellationToken);
            return Ok();
        }
        
        [HttpPost("{userId:guid}/dues")]
        [Authorize]
        public async Task<IActionResult> CreateUserDueAsync(
            [FromRoute] Guid userId,
            [FromBody] CreateDueCommand createDueCommand,
            CancellationToken cancellationToken)
        {
            createDueCommand.UserId = userId;

            await _userHandler.CreateUserDueAsync(createDueCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{userId:guid}/{dueId:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDueAsync(
            [FromRoute] Guid userId,
            [FromRoute] Guid dueId,
            [FromBody] UpdateDueAmountCommand updateDueAmountCommand,
            CancellationToken cancellationToken)
        {
            updateDueAmountCommand.UserId = userId;
            updateDueAmountCommand.DueId = dueId;

            await _userHandler.UpdateUserDueAsync(updateDueAmountCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{userId:guid}/{dueId:guid}/pay")]
        [Authorize]
        public async Task<IActionResult> PayUserDueAsync(
            [FromRoute] Guid userId,
            [FromRoute] Guid dueId,
            [FromBody] PayDueCommand payDueCommand,
            CancellationToken cancellationToken)
        {
            payDueCommand.UserId = userId;
            payDueCommand.DueId = dueId;

            await _userHandler.PayUserDueAsync(payDueCommand, cancellationToken);
            return Ok();
        }
    }
}
