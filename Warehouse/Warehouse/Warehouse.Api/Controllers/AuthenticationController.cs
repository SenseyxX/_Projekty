using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Contracts.Commands;
using Warehouse.Application.Dtos;
using Warehouse.Application.Handlers;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class AuthenticationController : Controller
    {
        private readonly AuthenticationHandler _authenticationHandler;

        public AuthenticationController(AuthenticationHandler authenticationHandler)
        {
            _authenticationHandler = authenticationHandler;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResultDto>> AuthenticateAsync(
            [FromBody] AuthenticateUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _authenticationHandler.AuthenticateAsync(
                command.Email,
                command.Password,
                cancellationToken);

            return Ok(result);
        }
    }
}
