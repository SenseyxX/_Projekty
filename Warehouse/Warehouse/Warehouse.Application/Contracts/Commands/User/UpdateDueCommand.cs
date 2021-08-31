using Warehouse.Domain.User.Enumeration;

namespace Warehouse.Application.Contracts.Commands
{
	 public sealed class UpdateDueCommand
	 {
		  public int Amount { get; set; }		  
		  DueStatus DueStatus { get; set; }
	 }
}
