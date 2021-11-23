using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Application.Contracts.Commands.Rental;
using Warehouse.Application.Dtos.Rental;
using Warehouse.Domain.Item;
using Warehouse.Domain.Rental;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Application.Handlers
{
    public sealed class RentalHandler
    {
        private readonly RentalDomainService _rentalDomainService;
        private readonly IRentalRepository _rentalRepository;
        private readonly IItemRepository _itemRepository;

        public RentalHandler(
            RentalDomainService rentalDomainService,
            IRentalRepository rentalRepository,
            IItemRepository itemRepository)
        {
            _rentalDomainService = rentalDomainService;
            _rentalRepository = rentalRepository;
            _itemRepository = itemRepository;
        }

        public async Task CreateRentalAsync(
            CreateRentalCommand createRentalCommand,
            CancellationToken cancellationToken)
        {
            var rental = await _rentalDomainService.CreateRentalAsync(createRentalCommand.UserId,createRentalCommand.Name, cancellationToken);

            await _rentalRepository.CreateAsync(rental, cancellationToken);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task PickItemAsync(PickItemCommand pickItemCommand, CancellationToken cancellationToken)
        {
            var _ = await _itemRepository.GetByCodeAsync(pickItemCommand.ItemCode, cancellationToken)
                ?? throw new Exception();

            var rental = await _rentalRepository.GetAsync(pickItemCommand.RentalId, cancellationToken);

            var rentals = await _rentalRepository.GetRangeAsync(cancellationToken);

            if (rentals.Any(x => x.RentalItems
                .Any(rentalItem => rentalItem.RentalItemCode == pickItemCommand.ItemCode && rentalItem.RentalItemStatus == RentalItemStatus.Picked)))
            {
                throw new Exception();
            }

            rental.PickItem(pickItemCommand.ItemCode);

            _rentalRepository.Update(rental);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task FinishPickingAsync(
            FinishPickingCommand finishPickingCommand,
            CancellationToken cancellationToken)
        {
            var finishPicking = await _rentalRepository.GetAsync(finishPickingCommand.RentalId, cancellationToken);

            finishPicking.FinishPicking();

            _rentalRepository.Update(finishPicking);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task ReturnItemAsync(
            ReturnItemCommand returnItemCommand,
            CancellationToken cancellationToken)
        {
            var returnItem = await _rentalRepository.GetAsync(returnItemCommand.RentalId, cancellationToken);

            returnItem.ReturnItem(returnItemCommand.RentalItemCode);

            _rentalRepository.Update(returnItem);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task FinishReturningAsync(
            FinishReturningCommand finishReturningCommand,
            CancellationToken cancellationToken)
        {
            var finishReturning = await _rentalRepository.GetAsync(finishReturningCommand.RentalId, cancellationToken);

            finishReturning.FinishReturning();

            _rentalRepository.Update(finishReturning);
            await _rentalRepository.SaveAsync(cancellationToken);
        }

        public async Task<IEnumerable<RentalDto>> GetRentalsAsync(CancellationToken cancellationToken)
        {
            var rentals = await _rentalRepository.GetRangeAsync(cancellationToken);
            return rentals.Select(rental => (RentalDto) rental);
        }

        public async Task<FullRentalDto> GetRentalAsync(Guid rentalId, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetAsync(rentalId, cancellationToken);
            return (FullRentalDto) rental;
        }
    }
}
