using System;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Application.Contracts.Commands.User
{
	 public sealed class CreateDueCommand
	 {
		  public Guid UserId { get; set; }
		  public Half Half { get; init; }
		  public int Amount { get; init; }
	 }
}
