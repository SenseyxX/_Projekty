using System;
using System.Security.Claims;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Api.Controllers
{
    public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        protected const string RoutePattern = "api/[controller]";

		protected Guid GetSquadId()
		{
			var value = User.FindFirstValue(TokenService.TokenSquadIdKey);

			var result = Guid.TryParse(value, out var squadId);

			if (!result)
			{
				throw new Exception();
			}

			return squadId;
		}
    }
}