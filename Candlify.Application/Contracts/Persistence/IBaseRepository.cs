using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candlify.Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> ListAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateByIdAsync(Guid id, T entity);
        Task RemoveByIdAsync(Guid id);
    }
}
