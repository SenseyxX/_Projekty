using Mag.Dtos;
using Mag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public sealed class UserService : IUserService

        {
                private readonly IUserRepository _userRepository;

                public UserService(IUserRepository userRepository)
                {
                        _userRepository = userRepository;
                }

                public Task<IEnumerable<UserDto>> AddUserAsync(UserDto user)
                {
                        throw new NotImplementedException();
                }

                public Task<IEnumerable<UserDto>> DelateUserAsync(int userId)
                {
                        throw new NotImplementedException();
                }

                public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
                {
                        var users = await _userRepository.GetAllUsersAsync();
                        return users.Select(x => new UserDto 
                        { 
                        Id=x.Id,
                        Name=x.Name,
                        LastName=x.LastName,
                        SquadId=x.SquadId,
                        PasswordHash=x.PasswordHash,
                        Email=x.Email,
                        PhoneNumber=x.PhoneNumber
                        
                        });
                }

                public async Task<IEnumerable<UserDto>> GetUserAsync(int userId)
                {
                   /*      var user = await _userRepository.GetUserAsync(userId);
                          return user.Select(x => new UserDto 
                          { 
                                 Id=x.Id,
                                 Name=x.Name,
                                 LastName=x.LastName,
                                 SquadId=x.SquadId,
                                 PasswordHash=x.PasswordHash,
                                 Email=x.Email,
                                 PhoneNumber=x.PhoneNumber

                          });
                   */
                        throw  new NotImplementedException();
                }

                public Task<IEnumerable<UserDto>> UpdateUserAsync(UserDto user)
                {
                        throw new NotImplementedException();
                }
        }       
}
