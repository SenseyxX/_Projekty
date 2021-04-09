using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Repositories;

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

        [HttpGet]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid Id)
        {
            var result = await _itemService.GetItemAsync(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> AddItemAsync(Item item)
        {
            var result = await _itemService.AddItemAsync(item);
            return Ok(result);
        }

        [HttpDelete]        
        public async Task<ActionResult<ItemDto>> DeleteItemAsync(Guid Id)
        {
            await _itemService.DeleteItemAsync(Id);
            return Ok();
        }

    }
}
