using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddUserAsync(User user)
        {
            var result = await _userRepository.AddUserAsync(user);
            return (UserDto)result;
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            // await _userRepository.DelateUserAsync(Id);
        }

        public async Task<UserDto> GetUserAsync(Guid Id)
        {
            var result = await _userRepository.GetUserAsync(Id);
            return (UserDto)result;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetRangeAsync(cancellationToken);
            return users.Select(user => (UserDto)user);
        }
        //ToDo
        public Task UpdateUserAsync(User user, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
