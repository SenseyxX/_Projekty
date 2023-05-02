using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Category;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;
using Warehouse.Domain.Squad;
using Warehouse.Domain.User;

namespace Warehouse.Domain.Item.Factories
{
    public sealed class ItemFactory // Factory tworzące nowe itemy
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
		private readonly ISquadRepository _squadRepository;

        public ItemFactory(
			ICategoryRepository categoryRepository,
			IUserRepository userRepository,
			IItemRepository itemRepository,
			ISquadRepository squadRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
			_squadRepository = squadRepository;
		}

		public async Task<Entities.Item> CreateAsync(
			Guid squadId,
			string name,
			string description,
			Guid categoryId,
			QualityLevel qualityLevel,
			int quantity,
			Guid ownerId,
			CancellationToken cancellationToken)
		{
			var squad = await _squadRepository.GetAsync(squadId, cancellationToken);

			var owner = squad.Users.FirstOrDefault(user => user.Id == ownerId);

			if (owner == null)
			{
				throw new Exception();
			}

			var item = new Entities.Item(
				Guid.NewGuid(),
				name,
				description,
				categoryId,
				qualityLevel,
				quantity,
				State.Active,
				ownerId,
				ownerId);

			return item;
		}

        public async Task<ICollection<Entities.Item>> CreateAsync(
			Guid squadId,
			ICollection<ItemModel> itemModels,
			CancellationToken cancellationToken)
		{
			var squad = await _squadRepository.GetAsync(squadId, cancellationToken);
            var categories = await _categoryRepository.GetRangeAsync(cancellationToken);

            var result = new List<Entities.Item>();

            foreach (var itemModel in itemModels)
            {
                var categoryId = categories.First(category => category.Name == itemModel.Category).Id;
                var owner = squad.Users.FirstOrDefault(user => user.Email == itemModel.Owner);
                var actualOwner = squad.Users.FirstOrDefault(user => user.Email == itemModel.ActualOwner);

				if (owner == null)
				{
					throw new Exception($"User: {itemModel.Owner} does not belong to squad.");
				}

				if (actualOwner == null)
				{
					throw new Exception();
				}

                var item = new Entities.Item(
                    Guid.NewGuid(),
                    itemModel.Name,
                    itemModel.Description,
                    categoryId,
                    itemModel.QualityLevel,
                    itemModel.Quantity,
                    State.Active,
                    owner.Id,
                    actualOwner.Id);

                result.Add(item);
                await _itemRepository.CreateAsync(item, cancellationToken);
            }

            return result;
        }
    }
}