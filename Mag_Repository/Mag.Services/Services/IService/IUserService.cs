using Mag.Dtos;
using Mag.Dtos.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IUserService
        {
                Task<IEnumerable<UserGetDto>> GetAllUsersAsync();                
                Task<UserGetDto> GetUserAsync(int userId);
                Task<UserGetDto> AddUserAsync(UserAddDto user);
                Task<UserGetDto> UpdateUserAsync(int id, UserUpdateDto user);
                Task DelateUserAsync(int userId); 
        }
}
