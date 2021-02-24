using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public sealed class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(MagContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Item>> GetRangeAsync()
        {
            return await Context.items.ToListAsync();
        }

       
    }
}
