using Mag.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IUserService
        {
                Task<IEnumerable<UserDto>> GetAllUsersAsync();
                // ?????????????????????????????????????????????????????
                Task<IEnumerable<UserDto>> GetUserAsync(int userId);
                Task<IEnumerable<UserDto>> AddUserAsync(UserDto user);
                Task<IEnumerable<UserDto>> UpdateUserAsync(UserDto user);
                Task<IEnumerable<UserDto>> DelateUserAsync(int userId); 
        }
}
