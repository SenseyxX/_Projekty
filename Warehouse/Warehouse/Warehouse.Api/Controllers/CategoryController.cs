using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
using Warehouse.Persistence.Entities;

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
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoriesAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(Guid Id)
        {
            var result = await _categoryService.GetCategoryAsync(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategoryAsync(Category category )
        {
            var result = await _categoryService.AddCategoryAsync(category);
            return Ok(result);
        }
    }
}
