using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories.IRepository
{
        public class QualityRepository : IQualityRepository
        {
                private readonly MagContext _magContext;
                public QualityRepository(MagContext magContext)
                {
                        this._magContext = magContext;
                }

                public async Task<IEnumerable<Quality>> GetAllQualityAsync()
                {
                        var result = await _magContext.qualities.ToListAsync();
                        return result;
                }

                public async Task<Quality> GetQualityAsync(int qualityId)
                {
                        var result = await _magContext.qualities
                                   .FirstOrDefaultAsync(m => m.Id == qualityId);
                        return result;
                }
        }
}
