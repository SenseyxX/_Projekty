using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class UserRepository :IUserRepository
        {
                private readonly MagContext _context;
        
                public UserRepository(MagContext context)
                {
                        _context = context;
                }

                public async Task<ICollection<User>> GetRangeAsync()
                {
                        return await _context.users.ToListAsync();
                }

             

        }
}
