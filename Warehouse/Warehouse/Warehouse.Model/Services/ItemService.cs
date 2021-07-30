﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.DomainServices;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Factories;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class ItemService : IItemService // Główne metody do edycji danych na bazie
    {
        private readonly IItemRepository _itemRepository;
        private readonly ItemDomainService _itemDomainService;

        public ItemService(IItemRepository itemRepository, ItemDomainService itemDomainService)
        {
            _itemRepository = itemRepository;
            _itemDomainService = itemDomainService;
        }

        public async Task<FullItemDto> GetItemAsync(Guid id, CancellationToken cancellationToken) // Pobieranie Itemu o podanym Id
        {
            var item = await _itemRepository.GetAsync(id, cancellationToken);
            return (FullItemDto) item;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken) // Pobranie wszystkich Itemów
        {
            var items = await _itemRepository.GetRangeAsync(cancellationToken);
            return items.Select(item => (ItemDto) item);
        }

        public async Task CreateItemAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken) // Stworznie nowego Itemu
        {
            var item = ItemFactory.Create(
                createItemCommand.Name,
                createItemCommand.Description,
                createItemCommand.CategoryId,
                createItemCommand.QualityLevel,
                createItemCommand.Quantity,
                createItemCommand.OwnerId,
                createItemCommand.ActualOwnerId);

            await _itemRepository.CreateAsync(item, cancellationToken);
            await _itemRepository.SaveAsync(cancellationToken);
        }

        public async Task UpdateItemAsync(
            UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var item = await _itemRepository.GetAsync(updateItemCommand.ItemId, cancellationToken);
            var isUpdated = item.UpdateName(updateItemCommand.Name);
            isUpdated = item.UpdateOwner(updateItemCommand.OwnerId) || isUpdated;
            isUpdated = item.UpdateQuantity(updateItemCommand.Quantity) || isUpdated;
            isUpdated = item.UpdateDescription(updateItemCommand.Description) || isUpdated;
=======
            var item = await _itemRepository.GetAsync(updateItemCommand.OwnerId, cancellationToken);
            var isUpdated = item.UpdateName(updateItemCommand.Name);
            isUpdated = item.UpdateOwner(updateItemCommand.OwnerId)||isUpdated;
            isUpdated = item.UpdateQuantity(updateItemCommand.Quantity) || isUpdated;
            isUpdated = item.UpdateDescription(updateItemCommand.Description)||isUpdated;
>>>>>>> main

            if (isUpdated)
            {
                _itemRepository.Update(item);
                await _itemRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task DeleteItemAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetAsync(id, cancellationToken);
            var updated = item.Delete();

            if (updated)
            {
                _itemRepository.Update(item);
                await _itemRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<LoanHistoryDto>> GetItemLoanHistoriesAsync(
            Guid itemId,
            CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetAsync(itemId, cancellationToken);
            return item.LoanHistories.Select(loanHistory => (LoanHistoryDto) loanHistory);
        }

        public async Task LoanItemAsync(LoanItemCommand loanItemCommand, CancellationToken cancellationToken)
        {
            await _itemDomainService.LoanItemAsync(loanItemCommand.ItemId, loanItemCommand.ReceiverId, cancellationToken);
        }
    }
}
