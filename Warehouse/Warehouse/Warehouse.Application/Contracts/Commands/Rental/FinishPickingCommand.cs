using System;

namespace Warehouse.Application.Contracts.Commands.Rental
{
    public sealed class FinishPickingCommand
    {
        public Guid RentalId { get; set; }
    }
}