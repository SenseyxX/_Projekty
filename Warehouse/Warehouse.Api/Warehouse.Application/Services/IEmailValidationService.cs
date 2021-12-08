using System.Threading;
using System.Threading.Tasks;

namespace Warehouse.Infrastructure.Services
{
    public interface IEmailValidationService
    {
        Task<bool> IsUniqueAsync(string email, CancellationToken cancellationToken);
    }
}