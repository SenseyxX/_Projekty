using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateItemCommand
    {
        public Guid ItemId { get; set; }
        public string Name { get; init; }
        public Guid OwnerId { get; init; }
        public string Description { get; init; }
        public int Quantity { get; init; }
    }
}
