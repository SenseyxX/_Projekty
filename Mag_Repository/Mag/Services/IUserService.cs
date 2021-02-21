using Mag.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IUserService
        {
                Task<IEnumerable<UserDto>>GetRangeAsync();
        }
}
