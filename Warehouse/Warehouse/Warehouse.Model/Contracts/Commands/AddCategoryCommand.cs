namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
