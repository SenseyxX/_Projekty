using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.ItemDtos;
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
                private readonly IMapper _mapper;

        public ItemController(IItemRepository itemRepository, IMapper mapper)
                {
                        _itemRepository = itemRepository;
                        _mapper = mapper;
        }

                [HttpGet]
                public async Task<ActionResult> GetAllItems()
                {
                        try
                        {
                                var result = await _itemRepository.GetAllItemsAsync();
                                var resultDto = _mapper.Map<IEnumerable<ItemGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<ItemGetIdDto>> GetItemAsync(int Id)
                {
                        try
                        {
                                var result = await _itemRepository.GetItemAsync(Id);
                                var resultDto = _mapper.Map<ItemGetIdDto>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost("{Id:int}")]
                public async Task<ActionResult> AddItem(ItemGetDto itemDto)
                {
                        var item = _mapper.Map<Item>(itemDto);
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
                public async Task<ActionResult<Item>> UpdateItem(int Id, ItemGetDto itemGetDto)
                {
                        try
                        {
                                if (Id != itemGetDto.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var itemToUpdate = await _itemRepository.GetItemAsync(Id);

                                if (itemToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(itemGetDto, itemToUpdate);
                                await _itemRepository.UpdateItemAsync(itemToUpdate);
                                return NoContent();
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
                                var itemToDelete = await _itemRepository.GetItemAsync(Id);
                                if (Id != itemToDelete.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                

                                if (itemToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map<ItemDeleteDto>(itemToDelete);
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
