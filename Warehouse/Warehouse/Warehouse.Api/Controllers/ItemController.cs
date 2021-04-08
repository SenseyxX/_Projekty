using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Api.Controllers
{
        [ApiController]
        [Microsoft.AspNetCore.Components.Route(RoutePattern)]
        public class ItemController : Controller
        {          
                public ItemController()
                {
                        
                }
        }
}
