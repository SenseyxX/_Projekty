using Mag.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mag.Repositories.IRepository
{
        public interface IQualityRepository
        {
                Task<IEnumerable<Quality>> GetAllQualityAsync();
                Task<Quality> GetQualityAsync(int qualityId);

        }
}
