using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanHistoryDto>>> GetLoanHistories(CancellationToken cancelationToken)
        {
            var result = await _loanHistoryService.GetLoanHistoriesAsync(cancelationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<LoanHistoryDto>> GetLoanHistory(Guid Id)
        {
            var result = await _loanHistoryService.GetLoanHistory(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<LoanHistoryDto>> AddLoanHistory(LoanHistory loanHistory)
        {
            var result = await _loanHistoryService.AddLoanHistory(loanHistory);
            return Ok(result);
        }
    }
}
