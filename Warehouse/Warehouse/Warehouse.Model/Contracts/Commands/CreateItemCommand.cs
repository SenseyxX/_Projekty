using System;
using Warehouse.Persistence.Entities.Item;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class CreateItemCommand
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public Guid CategoryId { get; init; }
        public QualityLevel QualityLevel { get; init; }
        public int Quantity { get; set; }
        public Guid? OwnerId { get; init; }
        public Guid ActualOwnerId { get; init; }
    }
}
