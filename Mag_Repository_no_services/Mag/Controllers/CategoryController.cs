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

                public CategoryController(ICategoryRepository categoryRepository)
                {
                        this._categoryRepository = categoryRepository;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllUsers()
                {

                        try
                        {
                                var result = await _categoryRepository.GetAllCategoriesAsync();
                                return Ok(result);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<Category>> GetUser(int Id)
                {

                        try
                        {
                                var result = await _categoryRepository.GetCategoryAsync(Id);

                                if (result == null)
                                {
                                        return NotFound();
                                }

                                return Ok(result);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost]
                public async Task<ActionResult<Category>> AddUser(Category user)
                {
                        try
                        {
                                if (user == null)
                                {
                                        return BadRequest();
                                }

                                var createdCategory = await _categoryRepository.AddCategoryAsync    (user);
                                return CreatedAtAction(nameof(GetUser), new { Id = createdCategory.Id },
                                        createdCategory);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpPut("{Id:int}")]

                public async Task<ActionResult<Category>> UpdateUser(int Id, Category user)
                {
                        try
                        {
                                if (Id != user.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var userToUpdate = await _categoryRepository.GetCategoryAsync(Id);

                                if (userToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _categoryRepository.UpdateCategoryAsync(user);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<Category>> DeleteUser(int Id, Category user)
                {
                        try
                        {
                                if (Id != user.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var userToDelete = await _categoryRepository.GetCategoryAsync(Id);

                                if (userToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

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
