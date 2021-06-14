using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;
using Warehouse.Model.Helpers;
using Warehouse.Persistence.Factories;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptionService _encryptionService;

        public UserService(IUserRepository userRepository, EncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public async Task AddUserAsync(
            AddUserCommand addUserCommand,
            CancellationToken cancellationToken)
        {
            var passwordHash = _encryptionService.EncodePassword(addUserCommand.Password);

            var user = UserFactory.Create(
                addUserCommand.Name,
                addUserCommand.LastName,
                passwordHash,
                addUserCommand.Email,
                addUserCommand.PhoneNumber,
                addUserCommand.PermissionLevel,
                addUserCommand.SquadId);

            await _userRepository.CreateAsync(user, cancellationToken);
            await _userRepository.SaveAsync(cancellationToken);
        }

        public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(id, cancellationToken);
            var updated = user.Delete();

            if (updated)
            {
                _userRepository.Update(user);
                await _userRepository.SaveAsync(cancellationToken);
            }
        }

        public async Task<UserDto> GetUserAsync(Guid id, CancellationToken cancellationToken)
           => (UserDto)await _userRepository.GetAsync(id, cancellationToken);

        public async Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetRangeAsync(cancellationToken);
            return users.Select(user => (UserDto)user);
        }

        // ToDo: Update
        public async Task UpdateUserAsync(
            // UpdateUserCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            // var user = await _userRepository.GetAsync(updateItemCommand.UserId, cancellationToken);
            // var isNameUpdated = user.UpdateName(updateItemCommand.Name);
            // var isLastNameUpdated = user.UpdateLastName(updateItemCommand.LastName);
            // var isPasswordHashUpdated = user.UpdatePasswordHash(updateItemCommand.PasswordHash);
            // var isEmailUpdated = user.UpdatePasswordHash(updateItemCommand.Email);
            // var isPhoneNumberUpdated = user.UpdatePhoneNumber(updateItemCommand.Email);

            // if (isNameUpdated || isLastNameUpdated || isPasswordHashUpdated || isEmailUpdated || isPhoneNumberUpdated)
            // {
            //     _userRepository.Update(user);
            //     await _userRepository.SaveAsync(cancellationToken);
            // }
        }
    }
}
