namespace Warehouse.Application.Contracts.Commands.Category
{
    public sealed class CreateCategoryCommand
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
