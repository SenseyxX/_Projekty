using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Rental;
using Warehouse.Domain.Rental;

namespace Warehouse.Application.Handlers
{
    public sealed class RentalHandler
    {
        private readonly RentalDomainService _rentalDomainService;
        private readonly IRentalRepository _rentalRepository;

        public RentalHandler(
            RentalDomainService rentalDomainService,
            IRentalRepository rentalRepository)
        {
            _rentalDomainService = rentalDomainService;
            _rentalRepository = rentalRepository;
        }

        public async Task CreateRentalAsync(
            CreateRentalCommand createRentalCommand,
            CancellationToken cancellationToken)
        {
            var rental = await _rentalDomainService.CreateRentalAsync(createRentalCommand.UserId, cancellationToken);

            await _rentalRepository.CreateAsync(rental, cancellationToken);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task PickItemAsync(PickItemCommand pickItemCommand, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetAsync(pickItemCommand.RentalId, cancellationToken);

            // ToDo: Add item status validation.
            rental.PickItem(pickItemCommand.ItemCode);

            _rentalRepository.Update(rental);
            await _rentalRepository.SaveAsync(cancellationToken);
        }
    }
}
