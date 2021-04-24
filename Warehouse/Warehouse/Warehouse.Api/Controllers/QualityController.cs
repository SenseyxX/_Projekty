using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class QualityController : Controller
    {
        private readonly IQualityService _qualityService;

        public QualityController(IQualityService qualityService)
        {
            _qualityService = qualityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualityDto>>> GetQualitiesAsync(CancellationToken cancellationToken)
        {
            var result = await _qualityService.GetQualitiesAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{gualityId}")]
        public async Task<ActionResult<FullQualityDto>> GetQualityAsync(
            [FromRoute] Guid qualityId,
            CancellationToken cancellationToken)
        {
            var result = await _qualityService.GetQualityAsync(qualityId,cancellationToken);
            return Ok(result);
        }
    }
}
