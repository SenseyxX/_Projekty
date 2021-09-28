using System;

namespace Warehouse.Application.Contracts.Commands.User
{
	 public sealed class UpdateDueAmountCommand
	 {
         public Guid UserId { get; set; }
         public Guid DueId { get; set; }
         public int Amount { get; init; }
	 }
}
