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
    public sealed class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>>GetAsync()
        {
            var result = await _userService.GetRangeAsync();
            return Ok(result);

        }
       

        
    }
}
