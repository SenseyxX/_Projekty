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
        Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken);
        Task<FullUserDto> GetUserAsync(Guid id, CancellationToken cancellationToken);
        Task CreateUserAsync(CreateUserCommand createUserCommand, CancellationToken cancellationToken);
        Task UpdateUserAsync(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken);
        Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<DuesDto>> GetUsersDuesAsync(CancellationToken cancellationToken);
        Task<DuesDto> GetUserDuesAsync(Guid id, CancellationToken cancellationToken);
        Task CreateUserDuesAsync(CreateDuesCommand createDuesCommand, CancellationToken cancellationToken);
        Task UpdateUserDuesAsync(UpdateDuesCommand updateDuesCommand, CancellationToken cancellationToken);
        Task DeleteUserDuesAsync(Guid id, CancellationToken cancellationToken);
    }
}
