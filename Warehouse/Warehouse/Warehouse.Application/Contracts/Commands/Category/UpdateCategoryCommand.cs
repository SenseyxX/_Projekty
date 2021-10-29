using System;

namespace Warehouse.Application.Contracts.Commands.Category
{
    public sealed class UpdateCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
