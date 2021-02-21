using Mag.Dtos;
using Mag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public sealed class UserService:IUserService
        {
                private readonly IUserRepository _userRepository;
               

                public UserService(IUserRepository userRepository)
                {
                        _userRepository = userRepository;
                }


                public async Task<IEnumerable<UserDto>> GetRangeAsync()
                {
                        var users = await _userRepository.GetRangeAsync();

                        return users.Select(x => new UserDto
                        {
                                Id = x.Id,
                                Name = x.Name,

                        });


                }
        }
}
