using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Abstractions;
using Warehouse.Persistence.Entities.ItemList.Enums;

namespace Warehouse.Persistence.Entities.ItemList.Entities
{
	 public sealed class ItemList : Aggregate
	 {
		  public ItemList(
			   Guid id,
			   Guid userId,
			   ItemListStatus itemListStatus)
			   :base(id)
		  {
			   UserId = userId;
			   ItemListStatus = itemListStatus;
			   Item = new List<Item>();
		  }

		  public Guid UserId { get; }
		  public ItemListStatus ItemListStatus { get; private set; }
		  ICollection<Item> Item { get; }
	 }
}

