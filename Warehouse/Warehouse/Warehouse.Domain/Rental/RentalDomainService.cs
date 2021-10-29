using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Rental.Factories;
using Warehouse.Domain.User;

namespace Warehouse.Domain.Rental
{
    public sealed class RentalDomainService
    {
        private readonly IUserRepository _userRepository;

        public RentalDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Entities.Rental> CreateRentalAsync(Guid userId, CancellationToken cancellationToken)
        {
            var _ = await _userRepository.GetAsync(userId, cancellationToken)
                ?? throw new NullReferenceException();

            var rental = RentalFactory.Create(userId);
            return rental;
        }
    }
}
