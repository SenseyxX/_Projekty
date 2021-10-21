using System;

namespace Warehouse.Application.Contracts.Commands.Rental
{
    public sealed class PickItemCommand
    {
        public Guid RentalId { get; set; }
        public string ItemCode { get; init; }
    }
}
