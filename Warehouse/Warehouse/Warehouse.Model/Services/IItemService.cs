using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken);
        Task<FullItemDto> GetItemAsync(Guid id, CancellationToken cancellationToken);
        Task CreateItemAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken);
        Task UpdateItemAsync(UpdateItemCommand updateItemCommand, CancellationToken cancellationToken);
        Task DeleteItemAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<LoanHistoryDto>> GetItemLoanHistoriesAsync(
            Guid itemId,
            CancellationToken cancellationToken);

        Task LoanItemAsync(LoanItemCommand loanItemCommand, CancellationToken cancellationToken);
    }
}
