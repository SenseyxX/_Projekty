namespace Warehouse.Persistence.Entities
{
    public sealed class Role : Entity
    {
        // ToDo: Add permission level.
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
