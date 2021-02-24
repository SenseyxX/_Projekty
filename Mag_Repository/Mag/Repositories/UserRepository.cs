using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class UserRepository : BaseRepository<User>, IUserRepository
        {
        public UserRepository(MagContext context)
                : base(context){}
                

        public async Task<ICollection<User>> GetRangeAsync()
        {
                return await Context.users.ToListAsync();
        }
    }
}
