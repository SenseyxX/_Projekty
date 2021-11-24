using Mag.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mag.Repositories
{
        public sealed class SquadRepository : ISquadRepository
        {
                private readonly MagContext _magContext;

                public SquadRepository(MagContext magContext)
                {
                        this._magContext = magContext;

                }

                public async Task<Squad> AddSquadAsync(Squad squad)
                {
                        var result = await _magContext.squads.AddAsync(squad);
                        await _magContext.SaveChangesAsync();
                        return result.Entity;
                }

                public async Task<Squad> DelateSquadAsync(int squadId)
                {
                        var result = await _magContext.squads
                                .FirstOrDefaultAsync(m => m.Id == squadId);
                        await _magContext.SaveChangesAsync();
                        return result;
                }

                public async Task<IEnumerable<Squad>> GetAllSquadsAsync()
                {
                        var result = await _magContext.squads.ToListAsync();
                        return result;
                }

                public async Task<Squad> GetSquadAsync(int squadId)
                {
                        var result = await _magContext.squads
                                .FirstOrDefaultAsync(m => m.Id == squadId);
                        return result;
                }

                public async Task<Squad> UpdateSquadAsync(Squad squad)
                {
                        var result = await _magContext.squads
                                .FirstOrDefaultAsync(m => m.Id == squad.Id);
                        if (result != null)
                        {
                                result.Id = squad.Id;
                                result.SquadName = squad.SquadName;
                                result.SquadName = squad.SquadName;
                                result.City = squad.City;

                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }
        }
}
