using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> FindByIdAsync(int id);
    }
}
