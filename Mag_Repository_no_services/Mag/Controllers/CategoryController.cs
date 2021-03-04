using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.CategoryDtos;
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
        public class CategoryController:Controller
        {
                private readonly ICategoryRepository _categoryRepository;
                private readonly IMapper _mapper;

                public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
                {
                        this._categoryRepository = categoryRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllCategories()
                {

                        try
                        {
                                var result = await _categoryRepository.GetAllCategoriesAsync();
                                var resultDto = _mapper.Map<IEnumerable<CategoryGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<CategoryGetDto>> GetCategory(int Id)
                {

                        try
                        {
                                var result = await _categoryRepository.GetCategoryAsync(Id);
                                var resultDto = _mapper.Map<CategoryGetIdDto>(result);
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
                public async Task<ActionResult> AddCategory(CategoryAddDto categoryAddDto)
                {
                        var category = _mapper.Map<Category>(categoryAddDto);
                        try
                        {
                                if (categoryAddDto == null)
                                {
                                        return BadRequest();
                                }

                                var createdCategory = await _categoryRepository.AddCategoryAsync(category);
                                return CreatedAtAction(nameof(GetCategory), new { Id = createdCategory.Id },
                                        createdCategory);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr adding data to the database");
                        }

                }

                [HttpPut("{Id:int}")]

                public async Task<ActionResult<Category>> UpdateCategory(int Id, CategoryUpdateDto categoryUpdateDto)
                {
                        try
                        {                                     
                               
                                var categoryToUpdate = await _categoryRepository.GetCategoryAsync(Id);

                                if (categoryToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(categoryToUpdate, categoryUpdateDto);
                                return await _categoryRepository.UpdateCategoryAsync(categoryToUpdate);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<Category>> DeleteCategory(int Id)
                {
                        try
                        {                                
                                var categoryToDelete = await _categoryRepository.GetCategoryAsync(Id);

                                if (categoryToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map<CategoryDeleteDto>(categoryToDelete);
                                return await _categoryRepository.DelateCategoryAsync(Id);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr deleting data");
                        }
                }
        }
}
