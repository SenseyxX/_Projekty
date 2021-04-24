using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
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

        [HttpGet("{userId}")]
        public async Task<ActionResult<SquadDto>> GetSquadAsync(
            [FromRoute]Guid squadId,
            CancellationToken cancellationToken)
        {
            var result = await _squadService.GetSquadAsync(squadId,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddSquadAsync(
            AddSquadCommand addSquadCommand,
            CancellationToken cancellationToken)
        {
            await _squadService.AddSquadAsync(addSquadCommand,cancellationToken);
            return Ok();
        }
        //ToDo
        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await _squadService.DeleteSquadAsync(id);
            return Ok();
        }
    }
}
