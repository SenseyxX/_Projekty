using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories.IRepository
{
        public interface ILoanHistoryRepository
        {
                Task<IEnumerable<LoanHistory>> GetAllLoanHistoriesAsync();
                Task<LoanHistory> GetLoanHistoryAsync(int LoanHistoryid);
                Task<LoanHistory> AddLoanHistoryAsync(LoanHistory LoanHistory);
                Task<LoanHistory> UpdateLoanHistoryAsync(LoanHistory LoanHistory);
                Task<LoanHistory> DelateLoanHisotryAsync(int LoanHistorysquadId);
        }
}
