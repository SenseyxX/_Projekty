using System.Collections.Generic;

namespace Warehouse.Persistence.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
