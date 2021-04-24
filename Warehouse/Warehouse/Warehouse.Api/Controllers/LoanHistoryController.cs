using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Model.Services;
using Warehouse.Persistence.Entities;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class LoanHistoryController : Controller
    {
        private readonly ILoanHistoryService _loanHistoryService;

        public LoanHistoryController(ILoanHistoryService loanHistoryService)
        {
            _loanHistoryService = loanHistoryService;
        }

        [HttpGet("{loanhistoryId}")]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetLoanHistories(CancellationToken cancelationToken)
        {
            var result = await _loanHistoryService.GetLoanHistoriesAsync(cancelationToken);
            return Ok(result);
        }

    [HttpGet]
    public async Task<ActionResult<LoanHistoryDto>> GetLoanHistoryAsync(
        [FromRoute] Guid loanhistoryId,
        CancellationToken cancellationToken)
        {
            var result = await _loanHistoryService.GetLoanHistory(loanhistoryId,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddLoanHistory(            
            AddLoanHistoryCommand addLoanHistoryCommand,
            CancellationToken cancellationToken)
        {
            await _loanHistoryService.AddLoanHistory(addLoanHistoryCommand,cancellationToken);
            return Ok();
        }
    }
}
