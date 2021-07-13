using System;
using Warehouse.Persistence.Entities.Item;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class CreateItemCommand
    {
<<<<<<< HEAD
        public string Name { get; init; }
        public string Description { get; init; }
        public Guid CategoryId { get; init; }
        public QualityLevel QualityLevel { get; init; }
        public int Quantity { get; set; }
        public Guid? OwnerId { get; init; }
        public Guid ActualOwnerId { get; init; }
=======
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public QualityLevel QualityLevel { get; set; }
        public int Quantity { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid ActualOwnerId { get; set; }
>>>>>>> main
    }
}
