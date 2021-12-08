using System.Threading;
using System.Threading.Tasks;

namespace Warehouse.Infrastructure.Services
{
    public sealed class EmailValidationService : IEmailValidationService
    {
        public Task<bool> IsUniqueAsync(string email, CancellationToken cancellationToken)
        {
            
            throw new System.NotImplementedException();
        }
    }
}