using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public interface IItemRepository
    {
        Task<ICollection<Item>> GetRangeAsync();
    }
}
