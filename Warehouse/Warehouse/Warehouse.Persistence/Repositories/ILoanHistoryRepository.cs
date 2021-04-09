using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public interface ILoanHistoryRepository
    {
        Task<IEnumerable<LoanHistory>> GetLoanHistoriesAsync(CancellationToken cancellationToken);
        Task<LoanHistory> GetLoanHistoryAsync(Guid Id);
        Task<LoanHistory> AddLoanHistoryAsync(LoanHistory LoanHistory);
        Task<LoanHistory> UpdateLoanHistoryAsync(LoanHistory LoanHistory);
        Task<LoanHistory> DeleteLoanHisotryAsync(Guid Id);
    }
}
