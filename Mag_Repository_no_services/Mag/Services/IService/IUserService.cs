using Mag.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IUserService
        {
                Task<IEnumerable<SquadGetDto>> GetAllUsersAsync();
                // ?????????????????????????????????????????????????????
                Task<IEnumerable<SquadGetDto>> GetUserAsync(int userId);
                Task<IEnumerable<SquadGetDto>> AddUserAsync(SquadGetDto user);
                Task<IEnumerable<SquadGetDto>> UpdateUserAsync(SquadGetDto user);
                Task<IEnumerable<SquadGetDto>> DelateUserAsync(int userId); 
        }
}
