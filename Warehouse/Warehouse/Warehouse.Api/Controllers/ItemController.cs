using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Item;
using Warehouse.Application.Dtos.Item;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public class ItemController : Controller
    {
        private readonly ItemHandler _itemHandler;

        public ItemController(ItemHandler itemHandler)
        {
            _itemHandler = itemHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync(
            CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<FullItemDto>> GetItemAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemAsync(id,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItemAsync(
        [FromBody] CreateItemCommand createItemCommand,
        CancellationToken cancellationToken)
        {
            await _itemHandler.CreateItemAsync(createItemCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{itemId:guid}")]
        public async Task<IActionResult> DeleteItemAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)

        {
            await _itemHandler.DeleteItemAsync(itemId, cancellationToken);
            return Ok();
        }

        [HttpPut("{itemId:guid}")]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            updateItemCommand.ItemId = itemId;

            await _itemHandler.UpdateItemAsync(updateItemCommand, cancellationToken);
            return Ok();
        }

        [HttpGet("{itemId:guid}/loan-history")]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetItemLoanHistoryAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)
        {
            var result = await _itemHandler.GetItemLoanHistoriesAsync(itemId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{itemId:guid}/loan")]
        public async Task<IActionResult> LoanItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] LoanItemCommand loanItemCommand,
            CancellationToken cancellationToken)
        {
            loanItemCommand.ItemId = itemId;

            await _itemHandler.LoanItemAsync(loanItemCommand, cancellationToken);
            return Ok();
        }
    }
}
