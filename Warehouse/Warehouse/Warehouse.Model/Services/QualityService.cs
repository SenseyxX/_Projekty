using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class QualityService : IQualityService
    {
        private readonly IQualityRepository _qualityRepository;

        public QualityService(IQualityRepository qualityRepository)
        {
            _qualityRepository = qualityRepository;
        }

        public async Task<IEnumerable<QualityDto>> GetQualitiesAsync(CancellationToken cancellationToken)
        {
            var result = await _qualityRepository.GetRangeAsync(cancellationToken);
            return result.Select(quality => (QualityDto)quality);
        }

        public async Task<FullQualityDto> GetQualityAsync(Guid Id, CancellationToken cancellationToken)
            => (FullQualityDto)await _qualityRepository.GetAsync(Id, cancellationToken);
    }
}

