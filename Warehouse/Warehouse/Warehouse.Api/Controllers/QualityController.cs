using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
        [ApiController]
        [Microsoft.AspNetCore.Components.Route(RoutePattern)]
        public class QualityController : Controller
        {
                private readonly IQualityService _qualityService;

                public QualityController(IQualityService qualityService)
                {
                        _qualityService = qualityService;
                }

                
        }
}
