using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
        class LoanHistoryRepository : ILoanHistoryRepository
        {
                private readonly WarehouseContext _warehouseContext;

                public LoanHistoryRepository(WarehouseContext warehouseContext)
                {
                        _warehouseContext = warehouseContext;
                }

                public async Task<LoanHistory> AddLoanHistoryAsync(LoanHistory loanhistory)
                {
                        var result = await _warehouseContext.LoanHistories.AddAsync(loanhistory);
                        await _warehouseContext.SaveChangesAsync();
                        return null; // ? czy null jest ok ? 
                }

                public async Task<LoanHistory> DelateLoanHisotryAsync(Guid Id)
                {
                        var result = await _warehouseContext.LoanHistories
                                .FirstOrDefaultAsync(loanhistories => loanhistories.Id == Id);

                        _warehouseContext.LoanHistories.Remove(result);
                        await _warehouseContext.SaveChangesAsync();
                        return null;
                }

                public async Task<IEnumerable<LoanHistory>> GetAllLoanHistoriesAsync(CancellationToken cancellationToken)
                {
                        return await _warehouseContext.LoanHistories
                                .ToListAsync(cancellationToken);
                }

                public async Task<LoanHistory> GetLoanHistoryAsync(Guid Id)
                {
                        return await _warehouseContext.LoanHistories
                                .FirstOrDefaultAsync(loanhistory => loanhistory.Id == Id);
                }

                public Task<LoanHistory> UpdateLoanHistoryAsync(LoanHistory LoanHistory)
                {
                        throw new NotImplementedException();
                }
        }
}
