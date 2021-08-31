using System;

namespace Warehouse.Application.Contracts.Commands
{
    public sealed class UpdateSquadCommand
    {
        public Guid SquadId { get; set; }
        public string  Name { get; set; }
    }
}
