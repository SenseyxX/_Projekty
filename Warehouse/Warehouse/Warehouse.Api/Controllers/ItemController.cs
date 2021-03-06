﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync(
            CancellationToken cancellationToken)
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

        [HttpDelete("{itemId:guid}")]
        public async Task<IActionResult> DeleteItemAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)

        {
            await _itemService.DeleteItemAsync(itemId, cancellationToken);
            return Ok();
        }

        [HttpPut("{itemId:guid}")]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            updateItemCommand.ItemId = itemId;

            await _itemService.UpdateItemAsync(updateItemCommand, cancellationToken);
            return Ok();
        }

        [HttpGet("{itemId:guid}/loan-history")]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetItemLoanHistoryAsync(
            [FromRoute] Guid itemId,
            CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemLoanHistoriesAsync(itemId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{itemId:guid}/loan")]
        public async Task<IActionResult> LoanItemAsync(
            [FromRoute] Guid itemId,
            [FromBody] LoanItemCommand loanItemCommand,
            CancellationToken cancellationToken)
        {
            loanItemCommand.ItemId = itemId;

            await _itemService.LoanItemAsync(loanItemCommand, cancellationToken);
            return Ok();
        }
    }
}
