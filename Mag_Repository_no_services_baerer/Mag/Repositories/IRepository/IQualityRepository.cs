using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories.IRepository
{
        public interface IQualityRepository
        {
                Task<IEnumerable<Quality>> GetAllQualityAsync();
                Task<Quality> GetQualityAsync(int qualityId);
               
        }
}
