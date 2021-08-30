using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
