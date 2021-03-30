using Mag.Entities;
using System.Collections.Generic;
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

        }
}
