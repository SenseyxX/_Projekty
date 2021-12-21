using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Contracts.Commands.Rental;
using Warehouse.Application.Dtos.Rental;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public class RentalController : Controller
    {
        private readonly RentalHandler _rentalHandler;
        
        public RentalController(RentalHandler rentalHandler)
        {
            _rentalHandler = rentalHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetRentalsAsync(
            CancellationToken cancellationToken)
        {
            var result = await _rentalHandler.GetRentalsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{rentalId:guid}")]
        public async Task<ActionResult<FullRentalDto>> GetRentalAsync(
            [FromRoute] Guid rentalId,
            CancellationToken cancellationToken)
        {
            var rental = await _rentalHandler.GetRentalAsync(rentalId, cancellationToken);
            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRentalAsync(
            [FromBody] CreateRentalCommand createRentalCommand,
            CancellationToken cancellationToken)
        {
            await _rentalHandler.CreateRentalAsync(createRentalCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("{rentalId:guid}/picking")]
        public async Task<IActionResult> PickingAsync(
            [FromRoute] Guid rentalId,
            [FromBody] PickItemCommand pickItemCommand,
            CancellationToken cancellationToken)
        {
            pickItemCommand.RentalId = rentalId;

            await _rentalHandler.PickItemAsync(pickItemCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("{rentalId:guid}/finishPicking")]
        public async Task<IActionResult> FinishPickingAsync(
            [FromRoute] Guid rentalId,
            [FromBody] FinishPickingCommand finishPickingCommand,
            CancellationToken cancellationToken)
        {
            finishPickingCommand.RentalId = rentalId;

            await _rentalHandler.FinishPickingAsync(finishPickingCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("{rentalId:guid}/returnItem")]
        public async Task<IActionResult> ReturnItemsAsync(
            [FromRoute] Guid rentalId,
            [FromBody] ReturnItemCommand returnItemCommand,
            CancellationToken cancellationToken)
        {
            returnItemCommand.RentalId = rentalId;
            
            await _rentalHandler.ReturnItemAsync(returnItemCommand, cancellationToken);
            return Ok();
        }

        [HttpPost("{rentalId:guid}/finishReturning")]
        public async Task<IActionResult> FinishReturningAsync(
            [FromRoute] Guid rentalId,
            [FromBody] FinishReturningCommand finishReturningCommand,
            CancellationToken cancellationToken)
        {
            finishReturningCommand.RentalId = rentalId;

            await _rentalHandler.FinishReturningAsync(finishReturningCommand, cancellationToken);
            return Ok();
        }
    }
}