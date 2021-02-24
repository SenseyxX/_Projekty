using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();       
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save(T entity);
    }
}
