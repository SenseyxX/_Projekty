using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class ItemFactory
    {
        public static Item Create(string name, string description)
            => new Item(Guid.NewGuid(), name, description);
    }
}
