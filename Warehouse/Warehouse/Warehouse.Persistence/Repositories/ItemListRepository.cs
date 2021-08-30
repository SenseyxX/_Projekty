using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.ItemList.Entities;

namespace Warehouse.Persistence.Repositories
{
	 public sealed class ItemListRepository : Repository<ItemList>, IItemListRepository
	 {
		  public ItemListRepository(WarehouseContext warehauseContext)
			   :base(warehauseContext)
		  {
		  }

		  public async override Task<ItemList> GetAsync(Guid id, CancellationToken cancellationToken)
			  => await DbContext
				    .Set<ItemList>()
				    .Include(item => item.Id)
				    .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

		  public async override Task<ICollection<ItemList>> GetRangeAsync(CancellationToken cancellationToken)
			   => await DbContext
					.Set<ItemList>()
					.Include(item => item.Id)
					.ToListAsync(cancellationToken);
	 }	 
}
