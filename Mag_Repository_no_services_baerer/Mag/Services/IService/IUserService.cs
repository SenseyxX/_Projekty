using Mag.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IUserService
        {
                Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
                
                Task<IEnumerable<UserGetDto>> GetUserAsync(int userId);
                Task<IEnumerable<UserGetDto>> AddUserAsync(UserGetDto user);
                Task<IEnumerable<UserGetDto>> UpdateUserAsync(UserGetDto user);
                Task<IEnumerable<UserGetDto>> DelateUserAsync(int userId); 
        }
}
