using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync(CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<FullItemDto>> GetItemAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemAsync(id,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItemAsync(
        [FromBody] CreateItemCommand createItemCommand,
        CancellationToken cancellationToken)
        {
            await _itemService.CreateItemAsync(createItemCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] Guid itemId, CancellationToken cancellationToken)
        {
            await _itemService.DeleteItemAsync(itemId, cancellationToken);
            return Ok();
        }

        // ToDo: Update
        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] Guid categoryId,
            // [FromBody] UpdateCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            // updateItemCommand.itemId = categoryId;

            // await _itemService.UpdateItemAsync(updateItemCommand, cancellationToken);
            return Ok();
        }

        [HttpGet("{itemId}/loan-history")]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetItemLoanHistoryAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemLoanHistoriesAsync(itemId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{itemId}/loan")]
        public async Task<IActionResult> LoanItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] LoanItemCommand loanItemCommand,
            CancellationToken cancellationToken)
        {
            loanItemCommand.ItemId = itemId;

            await _itemService.LoanItemAsync(loanItemCommand, cancellationToken);
            return Ok();
        }

        // [HttpGet("{loanhistoryId}")]
        // public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetLoanHistories(CancellationToken cancelationToken)
        // {
        //     var result = await _loanHistoryService.GetLoanHistoriesAsync(cancelationToken);
        //     return Ok(result);
        // }
        //
        // [HttpGet]
        // public async Task<ActionResult<LoanHistoryDto>> GetLoanHistoryAsync(
        //     [FromRoute] Guid loanhistoryId,
        //     CancellationToken cancellationToken)
        // {
        //     var result = await _loanHistoryService.GetLoanHistory(loanhistoryId,cancellationToken);
        //     return Ok(result);
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult> AddLoanHistory(
        //     AddLoanHistoryCommand addLoanHistoryCommand,
        //     CancellationToken cancellationToken)
        // {
        //     await _loanHistoryService.AddLoanHistory(addLoanHistoryCommand,cancellationToken);
        //     return Ok();
        // }
    }
}
