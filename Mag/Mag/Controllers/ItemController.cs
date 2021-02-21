using Mag.Dtos;
using Mag.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAsync()
        {
            var result = await _itemService.GetRangeAsync();
            return Ok(result);
        }
    }
}
