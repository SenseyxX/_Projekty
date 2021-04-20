using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Factories;
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
        public async Task AddLoanHistory(
            AddLoanHistoryCommand addLoanHistoryCommand,
            CancellationToken cancellationToken)
        {
            var loanhistory = LoanHistoryFactory.Create(addLoanHistoryCommand.Timestamp);
            await _loanHistory.CreateAsync(loanhistory, cancellationToken);
            await _loanHistory.SaveAsync(cancellationToken);            
        }

        public async Task<IEnumerable<LoanHistoryDto>> GetLoanHistoriesAsync(CancellationToken cancellationToken)
        {
            var result = await _loanHistory.GetRangeAsync(cancellationToken);
            return result.Select(loanhistory => (LoanHistoryDto)loanhistory);
        }

        public async Task<LoanHistoryDto> GetLoanHistory(Guid id, CancellationToken cancellationToken)
            => (LoanHistoryDto)await _loanHistory.GetAsync(id, cancellationToken);   
    }
}
