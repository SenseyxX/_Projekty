using System;

namespace Warehouse.Application.Contracts.Commands.Squad
{
    public sealed class AddUserToTeamCommand
    {
        public Guid userId { get; set; }
        public Guid squadId { get; init; }
        public Guid teamId { get; set; }
    }
}