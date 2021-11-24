using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.User;
using Warehouse.Application.Dtos.User;
using Warehouse.Application.Services;
using Warehouse.Domain.User;
using Warehouse.Domain.User.Factories;

namespace Warehouse.Application.Handlers
{
    public sealed class UserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public UserHandler(IUserRepository userRepository, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public async Task CreateUserAsync(
            CreateUserCommand addUserCommand,
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

		  public async Task<FullUserDto> GetUserAsync(Guid id, CancellationToken cancellationToken)
           => (FullUserDto)await _userRepository.GetAsync(id, cancellationToken);

          public async Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetRangeAsync(cancellationToken);
            return users.Select(user => (UserDto)user);
        }

		  public async Task UpdateUserAsync(
            UpdateUserCommand updateItemCommand,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(updateItemCommand.UserId, cancellationToken);
            var isUpdated = user.UpdateName(updateItemCommand.Name);
            isUpdated = user.UpdateLastName(updateItemCommand.LastName) || isUpdated;
            isUpdated = user.UpdateEmail(updateItemCommand.Email) || isUpdated;
            isUpdated = user.UpdatePhoneNumber(updateItemCommand.PhoneNumber) || isUpdated;

            if (isUpdated)
            {
                _userRepository.Update(user);
                await _userRepository.SaveAsync(cancellationToken);
            }
        }

          public async Task CreateUserDueAsync(CreateDueCommand createDueCommand, CancellationToken cancellationToken)
          {
              var user = await _userRepository.GetAsync(createDueCommand.UserId, cancellationToken);

              user.AddDue(createDueCommand.Half, createDueCommand.Amount);

              _userRepository.Update(user);
              await _userRepository.SaveAsync(cancellationToken);
          }

		  public async Task UpdateUserDueAsync(UpdateDueAmountCommand updateDueAmountCommand, CancellationToken cancellationToken)
          {
              var user = await _userRepository.GetAsync(updateDueAmountCommand.UserId, cancellationToken);

              user.UpdateDueAmount(updateDueAmountCommand.DueId, updateDueAmountCommand.Amount);

              _userRepository.Update(user);
              await _userRepository.SaveAsync(cancellationToken);
          }

          public async Task PayUserDueAsync(PayDueCommand payDueCommand, CancellationToken cancellationToken)
          {
              var user = await _userRepository.GetAsync(payDueCommand.UserId, cancellationToken);

              user.PayDue(payDueCommand.DueId);

              _userRepository.Update(user);
              await _userRepository.SaveAsync(cancellationToken);
          }

          public async Task<IEnumerable<DueDto>> GetUserDuesAsync(Guid id, CancellationToken cancellationToken)
          {
              var user = await _userRepository.GetAsync(id, cancellationToken);

              return user.Dues.Select(due => (DueDto) due);
          }
    }
}
