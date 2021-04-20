using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface ILoanHistoryService
    {
        Task<IEnumerable<LoanHistoryDto>> GetLoanHistoriesAsync(CancellationToken cancellationToken);
        Task<LoanHistoryDto> GetLoanHistory(Guid id, CancellationToken cancellationToken);
        Task AddLoanHistory(AddLoanHistoryCommand loanHistory, CancellationToken cancellationToken);
    }
}
