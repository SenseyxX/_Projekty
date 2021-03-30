using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class UserRepository : IUserRepository
        {
                private readonly MagContext _magContext;                

                public UserRepository(MagContext magContext)
                {
                        _magContext = magContext;                        
                }

                public async Task<User> AddUserAsync(User user)
                {

                        var newUser = new User()
                        {
                                Name = user.Name,
                                LastName = user.LastName,
                                SquadId = user.SquadId,
                                Email = user.Email,                                
                                PhoneNumber = user.PhoneNumber
                        };                     


                        var result = await _magContext.users.AddAsync(newUser);
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


                public async Task UpdateUserAsync(User user)
                {
                    _magContext.users.Update(user);
                    await _magContext.SaveChangesAsync();
                }
        }
}
