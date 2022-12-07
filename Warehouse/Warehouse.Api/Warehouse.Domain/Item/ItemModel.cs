using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Domain.Item
{
    public sealed class ItemModel
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public QualityLevel QualityLevel { get; init; }
        public int Quantity { get; init; }
        public string Owner { get; init; }
        public string ActualOwner { get; init; }
    }
}
