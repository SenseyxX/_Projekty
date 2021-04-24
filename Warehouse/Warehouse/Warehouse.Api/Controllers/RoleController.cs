using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{roleId}")]
        public async Task<ActionResult<RoleDto>> GetRoleAsync(
            [FromRoute]Guid roleId,
            CancellationToken cancellationToken)
        {
            var result = await _roleService.GetRoleAsync(roleId,cancellationToken);
            return Ok(result);
        }
    }
}
