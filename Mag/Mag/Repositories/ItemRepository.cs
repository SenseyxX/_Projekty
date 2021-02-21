using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public sealed class ItemRepository : IItemRepository
    {
        private readonly MagContext _context;

        public ItemRepository(MagContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Item>> GetRangeAsync()
        {
            return await _context.items.ToListAsync();
        }
    }
}
