using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
