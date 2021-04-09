using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface IQualityService
    {
        Task<IEnumerable<QualityDto>> GetQualitiesAsync(CancellationToken cancellationToken);
        Task<QualityDto> GetQualityAsync(Guid Id);
    }
}
