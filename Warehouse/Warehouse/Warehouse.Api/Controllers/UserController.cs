using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route(RoutePattern)]
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
    }
}
