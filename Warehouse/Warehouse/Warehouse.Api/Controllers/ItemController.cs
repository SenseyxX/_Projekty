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
        [FromRoute] Guid Id,
        CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemAsync(Id,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddItemAsync(
        Item item,
        CancellationToken cancellationToken)
        {
            await _itemService.AddItemAsync(item,cancellationToken);
            return Ok();
        }
        //ToDo
        [HttpDelete]        
        public async Task<ActionResult<ItemDto>> DeleteItemAsync(Guid Id)
        {
            await _itemService.DeleteItemAsync(Id);
            return Ok();
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItemAsync(
            [FromRoute] Guid categoryId,
            [FromBody] UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            updateItemCommand.itemId = categoryId;

            await _itemService.UpdateItemAsync(updateItemCommand, cancellationToken);
            return Ok();
        }
    }
}
