using Mag.Dtos;
using Mag.Dtos.UserDtos;
using Mag.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                private readonly IPasswordHasher<User> _passwordHasher;

                public UserRepository(MagContext magContext,IPasswordHasher<User> passwordHasher)
                {
                        _magContext = magContext;
                        _passwordHasher = passwordHasher;
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

                        var passwordHash = _passwordHasher.HashPassword(newUser, user.PasswordHash);
                        newUser.PasswordHash = passwordHash;


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

                public async Task<User> Login(UserLoginDto userLoginDto) => await _magContext.users
                    .Include(user => user.Role)
                    .FirstOrDefaultAsync(user => user.Email == userLoginDto.Email);


                public async Task UpdateUserAsync(User user)
                {
                    _magContext.users.Update(user);
                    await _magContext.SaveChangesAsync();
                }
        }
}
