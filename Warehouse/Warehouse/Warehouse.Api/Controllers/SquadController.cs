using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Warehouse.Application.Contracts.Commands.Squad;
using Warehouse.Application.Dtos.Squad;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class SquadController : Controller
    {
        private readonly SquadHandler _squadHandler;

        public SquadController(SquadHandler squadHandler)
        {
            _squadHandler = squadHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadDto>>> GetUsersAsync(
            CancellationToken cancellationToken)
        {
            var result = await _squadHandler.GetSquadsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{squadId:guid}")]
        public async Task<ActionResult<FullSquadDto>> GetSquadAsync(
            [FromRoute]Guid squadId,
            CancellationToken cancellationToken)
        {
            var result = await _squadHandler.GetSquadAsync(squadId,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddSquadAsync(
            CreateSquadCommand addSquadCommand,
            CancellationToken cancellationToken)
        {
            await _squadHandler.CreateSquadAsync(addSquadCommand,cancellationToken);
            return Ok();
        }

        [HttpDelete("{squadId:guid}")]
        public async Task<ActionResult> DeleteSquadAsync(
            [FromRoute] Guid squadId,
            CancellationToken cancellationToken)
        {
            await _squadHandler.DeleteSquadAsync(squadId, cancellationToken);
            return Ok();
        }
    }
}
