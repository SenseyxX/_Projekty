using System.Collections.Generic;
using Warehouse.Domain.Item;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class CreateItemsCommand
    {
        public IEnumerable<ItemModel> Models { get; init; }
    }
}
