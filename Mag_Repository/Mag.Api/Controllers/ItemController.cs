using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Mag.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public sealed class ItemController:Controller
        {
                private readonly IItemRepository _itemRepository;
                private readonly IMapper _mapper;

                public ItemController(IItemRepository itemRepository,IMapper mapper)
                {
                        this._itemRepository = itemRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllItem()
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
                public async Task<ActionResult<ItemGetIdDto>> GetItem(int Id)
                {

                        try
                        {
                                var result = await _itemRepository.GetItemAsync(Id);
                                var resultDto = _mapper.Map<ItemGetDto>(result);

                                if (result == null)
                                {
                                        return NotFound();
                                }

                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost]
                public async Task<ActionResult> AddItem(ItemAddDto itemAddDto)
                {
                        
                        try
                        {
                                var item = _mapper.Map<Item>(itemAddDto);
                                if (item == null)
                                {
                                        return BadRequest();
                                }

                                var createdUser = await _itemRepository.AddItemAsync(item);
                                return CreatedAtAction(nameof(GetItem), new { Id = createdUser.Id },
                                        createdUser);
                        }
                        catch (Exception e)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr adding data to the database");
                        }

                }

                [HttpPut("{Id:int}")]
                public async Task<ActionResult<Item>> UpdateItem(int Id, ItemAddDto itemAddDto)
                {
                        try
                        {
                                var itemToUpdate = await _itemRepository.GetItemAsync(Id);

                                if (itemToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(itemAddDto, itemToUpdate);
                                await _itemRepository.UpdateItemAsync(itemToUpdate);
                                return NoContent();

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")] //Dodać Mapper do http delete
                public async Task<ActionResult<Item>> DeleteItem(int Id)
                {
                        try
                        {
                                var itemToDelete = await _itemRepository.GetItemAsync(Id);

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
