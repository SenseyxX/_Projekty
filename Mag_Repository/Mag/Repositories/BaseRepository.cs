using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MagContext Context;

        protected BaseRepository(MagContext context)
        {
            Context = context;
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
