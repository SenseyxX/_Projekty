using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface ILoanHistoryService
    {
        Task<IEnumerable<LoanHistoryDto>> GetLoanHistoriesAsync(CancellationToken cancellationToken);
        Task<LoanHistoryDto> GetLoanHistory(Guid Id);
        Task<LoanHistoryDto> AddLoanHistory(LoanHistory loanHistory);
    }
}
