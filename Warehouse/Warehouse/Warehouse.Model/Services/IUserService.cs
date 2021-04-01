using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
