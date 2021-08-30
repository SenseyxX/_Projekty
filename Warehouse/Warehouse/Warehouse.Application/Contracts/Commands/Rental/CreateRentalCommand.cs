using System;

namespace Warehouse.Application.Contracts.Commands.Rental
{
    public sealed record CreateRentalCommand(Guid UserId);
    // public sealed class CreateRentalCommand
    // {
    //     public Guid UserId { get; init; }
    // }
}
