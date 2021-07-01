using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.DomainServices
{
    public sealed class ItemDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;

        public ItemDomainService(IUserRepository userRepository, IItemRepository itemRepository)
        {
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        public async Task LoanItemAsync(Guid itemId, Guid receiverId, CancellationToken cancellationToken)
        {
            _ = await _userRepository.GetAsync(receiverId, cancellationToken)
                       ?? throw new NullReferenceException();

            var item = await _itemRepository.GetAsync(itemId, cancellationToken);
            var updated = item.UpdateOwner(receiverId);

            if (updated)
            {
                _itemRepository.Update(item);
                await _itemRepository.SaveAsync(cancellationToken);
            }
        }
    }
}
