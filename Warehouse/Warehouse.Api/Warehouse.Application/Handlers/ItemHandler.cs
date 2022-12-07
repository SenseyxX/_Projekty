using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Item;
using Warehouse.Application.Dtos.Item;
using Warehouse.Domain.Category;
using Warehouse.Domain.Item;
using Warehouse.Domain.Item.Factories;
using Warehouse.Domain.User;

namespace Warehouse.Application.Handlers
{
    public sealed class ItemHandler // Główne metody do edycji danych na bazie
    {
        private readonly IItemRepository _itemRepository;
        private readonly ItemDomainService _itemDomainService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly ItemFactory _itemFactory;

        public ItemHandler(
            IItemRepository itemRepository,
            ItemDomainService itemDomainService,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository,
            ItemFactory itemFactory)
        {
            _itemRepository = itemRepository;
            _itemDomainService = itemDomainService;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _itemFactory = itemFactory;
        }

        public async Task<FullItemDto> GetItemAsync(Guid id, CancellationToken cancellationToken) // Pobieranie Itemu o podanym Id
        {
            var item = await _itemRepository.GetAsync(id, cancellationToken);
            return (FullItemDto) item;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken) // Pobranie wszystkich Itemów
        {
            var categories = await _categoryRepository.GetRangeAsync(cancellationToken);
            var users = await _userRepository.GetRangeAsync(cancellationToken);
            var items = await _itemRepository.GetRangeAsync(cancellationToken);

            return items.Select(item =>
            {
                var result = (ItemDto) item;
                result.CategoryName = categories.FirstOrDefault(category => category.Id == item.CategoryId)?.Name;
                result.OwnerName = users.FirstOrDefault(owner => owner.Id == item.OwnerId)?.FullName();
                result.ActualOwnerName = users.FirstOrDefault(actualOwner => actualOwner.Id == item.ActualOwnerId)?.FullName();
                return result;
            });
        }

        public async Task CreateItemAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken) // Stworznie nowego Itemu
        {
            var item = ItemFactory.Create(
                createItemCommand.Name,
                createItemCommand.Description,
                createItemCommand.CategoryId,
                createItemCommand.QualityLevel,
                createItemCommand.Quantity,
                createItemCommand.OwnerId);

            await _itemRepository.CreateAsync(item, cancellationToken);
            await _itemRepository.SaveAsync(cancellationToken);
        }

        public async Task CreateItemsAsync(CreateItemsCommand command, CancellationToken cancellationToken)
        {
            var _ = await _itemFactory.CreateAsync(command.Models.ToList(), cancellationToken);
            await _itemRepository.SaveAsync(cancellationToken);
        }

        public async Task UpdateItemAsync(
            UpdateItemCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetAsync(updateItemCommand.ItemId, cancellationToken);
            var isUpdated = item.UpdateName(updateItemCommand.Name);
            isUpdated = item.UpdateOwner(updateItemCommand.OwnerId) || isUpdated;
            isUpdated = item.UpdateCategory(updateItemCommand.CategoryId) || isUpdated;
            isUpdated = item.UpdateQuantity(updateItemCommand.Quantity) || isUpdated;
            isUpdated = item.UpdateDescription(updateItemCommand.Description) || isUpdated;
            isUpdated = item.UpdateQuality(updateItemCommand.QualityLevel) || isUpdated;

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

        public async Task UpdateItemQualityAsync(
            UpdateItemQualityCommand updateItemQualityCommand,
            CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetAsync(updateItemQualityCommand.ItemId, cancellationToken);
            var isUpdated = item.UpdateQuality(updateItemQualityCommand.QualityLevel);

            if (isUpdated)
            {
                _itemRepository.Update(item);
                await _itemRepository.SaveAsync(cancellationToken);
            }
        }
    }
}
