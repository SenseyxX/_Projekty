using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Abstractions;
using Warehouse.Persistence.Entities.ItemList.Enums;

namespace Warehouse.Persistence.Entities.ItemList.Entities
{
	 public sealed class Item : Entity
	 {
		  public Item(
			   Guid id,
			   string itemCode,
			   ItemStatus itemStatus)
			   :base(id)
		  {
			   ItemCode = itemCode;
			   ItemStatus = itemStatus;
		  }

		  public string ItemCode { get; }
		  public ItemStatus ItemStatus { get; }			   
	 }
}
