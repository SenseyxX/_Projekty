using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
using Warehouse.Persistence.Entities;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class SquadController : Controller
    {
        private readonly ISquadService _squadService;

        public SquadController(ISquadService squadService)
        {
            _squadService = squadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadDto>>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _squadService.GetSquadsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SquadDto>> GetUserAsync(Guid id)
        {
            var result = await _squadService.GetSquadAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SquadDto>> AddUserAsync(Squad squad)
        {
            var result = await _squadService.AddSquadAsync(squad);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await _squadService.DeleteSquadAsync(id);
            return Ok();
        }
    }
}
