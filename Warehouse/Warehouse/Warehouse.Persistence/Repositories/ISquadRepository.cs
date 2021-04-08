using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
        public interface ISquadRepository
        {
                Task<IEnumerable<Squad>> GetAllSquadsAsync(CancellationToken cancellationToken);
                Task<Squad> GetSquadAsync(Guid Id);
                Task<Squad> AddSquadAsync(Squad squad);
                Task<Squad> UpdateSquadAsync(Squad squad);
                Task<Squad> DelateSquadAsync(Guid Id);
        }
}
