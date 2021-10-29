using System;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Application.Contracts.Commands.Item
{
    public sealed class UpdateItemQualityCommand
    {
        public Guid ItemId { get; set; }
        public QualityLevel QualityLevel { get; init; }
    }
}
