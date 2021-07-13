using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
	 public sealed class TeamRepository : Repository<Team>, ITeamRepository
	 {
		  public TeamRepository(WarehouseContext warehouseContext)
				    : base(warehouseContext)
		  {
		  }
	 }
}
