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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoriesAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<FullCategoryDto>> GetCategoryAsync(
            [FromRoute] Guid categoryId,
            CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoryAsync(categoryId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(
            [FromBody] AddCategoryCommand addCategoryCommand,
            CancellationToken cancellationToken)
        {
            await _categoryService.AddCategoryAsync(addCategoryCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync(
            [FromRoute] Guid categoryId,
            [FromBody] UpdateCategoryCommand updateCategoryCommand,
            CancellationToken cancellationToken)
        {
            updateCategoryCommand.CategoryId = categoryId;

            await _categoryService.UpdateCategoryAsync(updateCategoryCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] Guid categoryId, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteCategoryAsync(categoryId, cancellationToken);
            return Ok();
        }
    }
}
