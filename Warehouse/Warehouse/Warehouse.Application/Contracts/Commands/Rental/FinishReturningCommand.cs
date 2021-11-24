using System;

namespace Warehouse.Application.Contracts.Commands.Rental
{
    public sealed class FinishReturningCommand
    {
        public Guid RentalId { get; set; }
    }
}