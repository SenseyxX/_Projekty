using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResultDto>> AuthenticateAsync(
            [FromBody] AuthenticateUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _authenticationService.AuthenticateAsync(
                command.Email,
                command.Password,
                cancellationToken);

            return Ok(result);
        }
    }
}
