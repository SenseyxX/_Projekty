using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
using Warehouse.Persistence.Entities;

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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            var result = await _userService.GetUserAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUserAsync(User user)
        {
            var result = await _userService.AddUserAsync(user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
