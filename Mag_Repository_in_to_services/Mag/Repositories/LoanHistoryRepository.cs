using Mag.Entities;
using Mag.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class LoanHistoryRepository : ILoanHistoryRepository
        {
                private readonly MagContext _magContext;

                public LoanHistoryRepository(MagContext magContext)
                {
                        this._magContext = magContext;
                }

                public async Task<LoanHistory> AddLoanHistoryAsync(LoanHistory LoanHistory)
                {
                        var result = await _magContext.LoanHistories.AddAsync(LoanHistory);
                        await _magContext.SaveChangesAsync();
                        return result.Entity;
                }

                public async Task<LoanHistory> DelateLoanHisotryAsync(int LoanHistorysquadId)
                {
                        var result = await _magContext.LoanHistories
                                .FirstOrDefaultAsync(m => m.Id == LoanHistorysquadId);
                        await _magContext.SaveChangesAsync();
                        return result;
                }

                public async Task<IEnumerable<LoanHistory>> GetAllLoanHistoriesAsync()
                {
                        var result = await _magContext.LoanHistories.ToListAsync();
                        return (result);
                }

                public async Task<LoanHistory> GetLoanHistoryAsync(int LoanHistoryid)
                {
                        var result = await _magContext.LoanHistories
                                .FirstOrDefaultAsync(m => m.Id == LoanHistoryid);
                        return result;
                }

                public async Task<LoanHistory> UpdateLoanHistoryAsync(LoanHistory LoanHistory)
                {
                        var result = await _magContext.LoanHistories
                                .FirstOrDefaultAsync(m => m.Id == LoanHistory.Id);
                        if (result != null)
                        {
                                result.Id = LoanHistory.Id;
                                result.ItemId = LoanHistory.ItemId;
                                result.LastOwnerId = LoanHistory.LastOwnerId;
                                result.ActualOwnerId = LoanHistory.ActualOwnerId;                                

                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }
        }
}
