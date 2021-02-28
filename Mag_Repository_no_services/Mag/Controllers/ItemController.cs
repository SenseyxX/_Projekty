using Mag.Dtos;
using Mag.Entities;
using Mag.Repositories;
using Microsoft.AspNetCore.Http;
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
                private readonly IItemRepository _itemRepository;

                public ItemController(IItemRepository itemRepository)
                {
                        _itemRepository = itemRepository;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllItems()
                {
                        try
                        {
                                var result = await _itemRepository.GetAllItemsAsync();
                                return Ok(result);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<Item>> GetItemAsync(int Id)
                {
                        try
                        {
                                var result = await _itemRepository.GetItemAsync(Id);
                                return Ok(result);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost("{Id:int}")]
                public async Task<ActionResult<Item>> AddItem(Item item)
                {
                        try
                        {
                                if (item == null)
                                {
                                        return BadRequest();
                                }
                                var createItem = await _itemRepository.AddItemAsync(item);
                                return CreatedAtAction(nameof(GetItemAsync), new { Id = createItem.Id },
                                        createItem);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                          "Erorr retrieving data from the database");
                        }
                }

                [HttpPut("{Id:int}")]
                public async Task<ActionResult<Item>> UpdateItem(int Id, Item item)
                {
                        try
                        {
                                if (Id != item.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var userToUpdate = await _itemRepository.GetItemAsync(Id);

                                if (userToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _itemRepository.UpdateItemAsync(item);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<Item>> DeleteItem(int Id, Item item)
                {
                        try
                        {
                                if (Id != item.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var userToDelete = await _itemRepository.GetItemAsync(Id);

                                if (userToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _itemRepository.DelateItemAsync(Id);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr deleting data");
                        }
                }
        }
}
