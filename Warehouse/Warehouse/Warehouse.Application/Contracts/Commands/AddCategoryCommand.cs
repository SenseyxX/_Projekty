namespace Warehouse.Application.Contracts.Commands
{
    public sealed class AddCategoryCommand
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
