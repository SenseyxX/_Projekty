using Mag.Dtos;
using Mag.Dtos.UserDtos;
using Mag.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public interface IUserRepository 
        {
                Task<IEnumerable<User>> GetAllUsersAsync();
                Task<User> GetUserAsync(int userId);
                Task<User> AddUserAsync(User user);
                Task UpdateUserAsync(User user);
                Task<User> DelateUserAsync(int userId);
                Task<User> Login(UserLoginDto userLoginDto);
                
        }
}
