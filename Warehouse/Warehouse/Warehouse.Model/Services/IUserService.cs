using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>>GetUsersAsync(CancellationToken cancellationToken);
        Task<UserDto>GetUserAsync(Guid Id);
        Task<UserDto>AddUserAsync(User user);
        Task UpdateUserAsync(User user, Guid Id);
        Task DeleteUserAsync(Guid Id);
        
    }
}
