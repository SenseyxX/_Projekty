using System.Collections.Generic;
using System.Threading.Tasks;
using Mag.Entities;

namespace Mag.Repositories
{
        public interface ISquadRepository
        {
                Task<IEnumerable<Squad>> GetAllSquadsAsync();
                Task<Squad> GetSquadAsync(int squadId);
                Task<Squad> AddSquadAsync(Squad squad);
                Task<Squad> UpdateSquadAsync(Squad squad);
                Task<Squad> DelateSquadAsync(int squadId);
        }
}
