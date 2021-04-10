using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class LoanHistoryService : ILoanHistoryService
    {
        private readonly ILoanHistoryRepository _loanHistory;

        public LoanHistoryService(ILoanHistoryRepository loanHistory)
        {
            _loanHistory = loanHistory;
        }
        public async Task<LoanHistoryDto> AddLoanHistory(LoanHistory loanHistory)
        {
            var result = await _loanHistory.AddLoanHistoryAsync(loanHistory);
            return (LoanHistoryDto)result;
        }

        public async Task<IEnumerable<LoanHistoryDto>> GetLoanHistoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _loanHistory.GetLoanHistoriesAsync(cancellationToken);
            return result.Select(loanhistory => (LoanHistoryDto)loanhistory);
        }

        public async Task<LoanHistoryDto> GetLoanHistory(Guid Id)
        {
            var result = await _loanHistory.GetLoanHistoryAsync(Id);
            return (LoanHistoryDto)result;
        }
    }
}
