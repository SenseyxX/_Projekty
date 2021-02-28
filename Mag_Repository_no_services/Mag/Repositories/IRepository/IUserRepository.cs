using Mag.Entities;
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
                Task<User> UpdateUserAsync(User user);
                Task<User> DelateUserAsync(int userId);
        }
}
