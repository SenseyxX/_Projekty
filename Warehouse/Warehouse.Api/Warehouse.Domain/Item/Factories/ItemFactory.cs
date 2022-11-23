using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Category;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;
using Warehouse.Domain.User;

namespace Warehouse.Domain.Item.Factories
{
    public sealed class ItemFactory // Factory tworzące nowe itemy
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;

        public ItemFactory(ICategoryRepository categoryRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        public static Entities.Item Create(
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            Guid ownerId)
            => new (
                Guid.NewGuid(),
                name,
                description,
                categoryId,
                qualityLevel,
                quantity,
                State.Active,
                ownerId,
                ownerId);

        public async Task<ICollection<Entities.Item>> CreateAsync(ICollection<ItemModel> itemModels, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetRangeAsync(cancellationToken);

            var ownerNames = itemModels
                .Select(model => model.Owner)
                .ToList();

            var actualOwnerNames = itemModels
                .Select(model => model.ActualOwner)
                .ToList();

            ownerNames.AddRange(actualOwnerNames);

            ownerNames = ownerNames.Distinct().ToList();

            var users = await _userRepository.GetUsersAsync(ownerNames, cancellationToken);

            var result = new List<Entities.Item>();

            foreach (var itemModel in itemModels)
            {
                var categoryId = categories.First(category => category.Name == itemModel.Category).Id;
                var ownerId = users.First(user => user.Email == itemModel.Owner).Id;
                var actualOwnerId = users.First(user => user.Email == itemModel.ActualOwner).Id;

                var item = new Entities.Item(
                    Guid.NewGuid(),
                    itemModel.Name,
                    itemModel.Description,
                    categoryId,
                    itemModel.QualityLevel,
                    itemModel.Quantity,
                    State.Active,
                    ownerId,
                    actualOwnerId);

                result.Add(item);
                await _itemRepository.CreateAsync(item, cancellationToken);
            }

            return result;
        }
    }
}
