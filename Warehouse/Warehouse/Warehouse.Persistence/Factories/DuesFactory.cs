using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.User.Enums;
using Half = Warehouse.Persistence.Entities.User.Enums.Half;

namespace Warehouse.Persistence.Factories
{
	 public static class DuesFactory
	 {
		  public static Dues Create(
			   Guid userId,
			   Half half,
			   int amount,
			   Status status)
			   => new(
				    Guid.NewGuid(),
				    userId,
				    Half.First, // ToDo nie wiem czy powinniśmy definiować tutaj połowę
				    amount,
				    Status.Waiting);
		
	 }
}
