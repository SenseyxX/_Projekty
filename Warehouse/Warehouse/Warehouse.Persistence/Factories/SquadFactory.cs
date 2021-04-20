using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class SquadFactory
    {
        public static Squad Create(string name)
            => new(Guid.NewGuid(), name);
    }
}
