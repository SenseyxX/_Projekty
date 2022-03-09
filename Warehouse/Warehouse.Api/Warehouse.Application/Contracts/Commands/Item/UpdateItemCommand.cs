using System;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class UpdateItemCommand
    {
        public Guid ItemId { get; set; }
        public string Name { get; init; }
        public Guid OwnerId { get; init; }
        public Guid CategoryId { get; init; }
        public string Description { get; init; }
        public int Quantity { get; init; }
        public QualityLevel QualityLevel { get; init; }
    }
}
