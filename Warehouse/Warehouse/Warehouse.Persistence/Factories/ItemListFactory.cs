using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.ItemList.Enums;

namespace Warehouse.Persistence.Factories
{
	 public static class ItemListFactory
	 {
		  public static ItemListFactory Create(
				   Guid userId,
				   ItemListStatus itemListStatus)
				   => new(
						Guid.NewGuid(),
						userId);
	 }
}
