using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<SquadDto>>> GetSquadsAsync(
            CancellationToken cancellationToken)
        {
            var result = await _squadHandler.GetSquadsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{squadOwnerId:guid}")]
        public async Task<ActionResult<FullSquadDto>> GetSquadAsync(
            [FromRoute] Guid squadOwnerId,
            CancellationToken cancellationToken)
        {
            var result = await _squadHandler.GetSquadAsync(squadOwnerId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddSquadAsync(
            CreateSquadCommand createSquadCommand,
            CancellationToken cancellationToken)
        {
            await _squadHandler.CreateSquadAsync(createSquadCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{squadId:guid}")]
        public async Task<IActionResult> UpdateSquadAsync(
            [FromRoute] Guid squadId,
            [FromBody] UpdateSquadCommand updateSquadCommand,
            CancellationToken cancellationToken)
        {
            updateSquadCommand.SquadId = squadId;

            await _squadHandler.UpdateSquadAsync(updateSquadCommand, cancellationToken);
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

        [HttpGet("{squadId:guid}/teams")]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeamsAsync(
            [FromRoute] Guid squadId,
            CancellationToken cancellationToken)
        {
            var result = await _squadHandler.GetSquadTeamsAsync(squadId, cancellationToken);
            return Ok(result);
        }

        //ToDo: verify why add users in same squad 
        [HttpPost("{squadId:guid}/teams")]
        public async Task<ActionResult> AddTeamAsync(
            [FromRoute] Guid squadId,
            [FromBody] CreateTeamCommand createTeamCommand,
            CancellationToken cancellationToken)
        {
            createTeamCommand.SquadId = squadId;

            await _squadHandler.CreateTeamAsync(createTeamCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("team/{teamId}/{userId}")]
        public async Task<ActionResult> AddUserToTeamAsync(
            [FromRoute] Guid teamId,
            [FromRoute] Guid userId,
            [FromBody] AddUserToTeamCommand addUserToTeamCommand,
            CancellationToken cancellationToken)
        {
            addUserToTeamCommand.teamId = teamId;
            addUserToTeamCommand.userId = userId;

            await _squadHandler.AddUserToTeamAsync(addUserToTeamCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("team/{teamId}")]
        public async Task<IActionResult> UpdateTeamAsync(
            [FromRoute] Guid teamId,
            [FromBody] UpdateTeamCommand updateTeamCommand,
            CancellationToken cancellationToken)
        {
            updateTeamCommand.TeamId = teamId;

            await _squadHandler.UpdateTeamAsync(updateTeamCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{squadId:guid}/teams/{teamId:guid}")]
        public async Task<ActionResult> DeleteTeamAsync(
            [FromRoute] Guid teamId,
            [FromRoute] Guid squadId,
            CancellationToken cancellationToken)
        {
            await _squadHandler.DeleteTeamAsync(squadId, teamId, cancellationToken);
            return Ok();
        }
    }
}
