namespace Warehouse.Api.Controllers
{
    public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        protected const string RoutePattern = "api/[controller]";
    }
}
