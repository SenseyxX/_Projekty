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

                public Task<IEnumerable<UserGetDto>> AddUserAsync(UserGetDto user)
                {
                        throw new NotImplementedException();
                }

                public Task<IEnumerable<UserGetDto>> DelateUserAsync(int userId)
                {
                        throw new NotImplementedException();
                }

                public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
                {
                        var users = await _userRepository.GetAllUsersAsync();
                        return users.Select(x => new UserGetDto
                        { 
                        //Id=x.Id,
                        Name=x.Name,
                        LastName=x.LastName,
                        SquadId=x.SquadId,                        
                        Email=x.Email,
                        PhoneNumber=x.PhoneNumber
                        
                        });
                }

                public async Task<IEnumerable<UserGetDto>> GetUserAsync(int userId)
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

                public Task<IEnumerable<UserGetDto>> UpdateUserAsync(UserGetDto user)
                {
                        throw new NotImplementedException();
                }
        }       
}
