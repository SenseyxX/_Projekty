using System.Collections.Generic;

namespace Warehouse.Persistence.Entities
{
    public sealed class Squad : Entity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
