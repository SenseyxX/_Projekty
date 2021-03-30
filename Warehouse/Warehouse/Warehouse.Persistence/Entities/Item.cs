namespace Warehouse.Persistence.Entities
{
    public sealed class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string QrCode { get; set; }
    }
}
