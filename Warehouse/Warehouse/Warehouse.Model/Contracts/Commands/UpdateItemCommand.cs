using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateItemCommand
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
