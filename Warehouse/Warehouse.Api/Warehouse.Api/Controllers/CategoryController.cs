using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Category;
using Warehouse.Application.Dtos.Category;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    // [Authorize(Roles = "AdminRequirement")]
    [Route(RoutePattern)]
    public class CategoryController : Controller
    {
        private readonly CategoryHandler _categoryHandler;

        public CategoryController(CategoryHandler categoryHandler)
        {
            _categoryHandler = categoryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync(
            CancellationToken cancellationToken)
        {
            var result = await _categoryHandler.GetCategoriesAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{categoryId:guid}")]
        public async Task<ActionResult<FullCategoryDto>> GetCategoryAsync(
            [FromRoute] Guid categoryId,
            CancellationToken cancellationToken)
        {
            var result = await _categoryHandler.GetCategoryAsync(categoryId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(
            [FromBody] CreateCategoryCommand addCategoryCommand,
            CancellationToken cancellationToken)
        {
            await _categoryHandler.AddCategoryAsync(addCategoryCommand, cancellationToken);
            return Ok();
        }

        [HttpPut("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync(
            [FromRoute] Guid categoryId,
            [FromBody] UpdateCategoryCommand updateCategoryCommand,
            CancellationToken cancellationToken)
        {
            updateCategoryCommand.CategoryId = categoryId;

            await _categoryHandler.UpdateCategoryAsync(updateCategoryCommand, cancellationToken);
            return Ok();
        }
        
        [HttpDelete("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync(
            [FromRoute] Guid categoryId,
            CancellationToken cancellationToken)
        {
            await _categoryHandler.DeleteCategoryAsync(categoryId, cancellationToken);
            return Ok();
        }
    }
}
