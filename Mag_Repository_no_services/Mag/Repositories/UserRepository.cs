using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class UserRepository : IUserRepository
        {
                private readonly MagContext _magContext;

                public UserRepository(MagContext magContext)
                {
                        this._magContext = magContext;
                }

                public async Task<User> AddUserAsync(User user)
                {
                        var result = await _magContext.users.AddAsync(user);
                        await _magContext.SaveChangesAsync();
                        return result.Entity;
                }

                public async Task<User> DelateUserAsync(int userId)
                {
                        var result = await _magContext.users
                                .FirstOrDefaultAsync(m => m.Id == userId);
                        if (result != null)
                        {
                                _magContext.users.Remove(result);
                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }

                public async Task<IEnumerable<User>> GetAllUsersAsync()
                {
                        var result = await _magContext.users.ToListAsync();
                        return (result);
                }

                public async Task<User> GetUserAsync(int userId )
                {
                        var result = await _magContext.users
                                .FirstOrDefaultAsync(m => m.Id == userId);
                        return result;
                }

                public async Task<User> UpdateUserAsync(User user)
                {
                        var result = await _magContext.users
                                .FirstOrDefaultAsync(m => m.Id == user.Id);
                        if (result != null)
                        {
                                result.Name = user.Name;
                                result.LastName = user.LastName;
                                result.SquadId = user.SquadId;
                                result.Email = user.Email;
                                result.PhoneNumber = user.PhoneNumber;

                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }
        }
}
