namespace Warehouse.Persistence.Entities.Role
{
    public sealed class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PerrmissionLevel PermissionLevel { get; set; }
    }
}
