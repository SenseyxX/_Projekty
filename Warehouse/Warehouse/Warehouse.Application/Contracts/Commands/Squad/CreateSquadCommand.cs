using System;

namespace Warehouse.Application.Contracts.Commands.Squad
{
    public sealed class CreateSquadCommand
    {
        public string Name { get; init; }
        public Guid SquadOwnerId { get; init; }
    }
}
