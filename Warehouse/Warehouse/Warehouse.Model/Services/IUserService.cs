using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>>GetUsersAsync(CancellationToken cancellationToken);
        Task<UserDto>GetUserAsync(Guid id, CancellationToken cancellationToken);
        Task AddUserAsync(AddUserCommand addUserCommand, CancellationToken cancellationToken);
        // Task UpdateUserAsync(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken);
        Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);
    }
}
