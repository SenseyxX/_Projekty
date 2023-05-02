using System;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class CreateItemCommand
    {
		public Guid SquadId { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Guid CategoryId { get; init; }
        public QualityLevel QualityLevel { get; init; }
        public int Quantity { get; init; }
        public Guid OwnerId { get; init; }
    }
}