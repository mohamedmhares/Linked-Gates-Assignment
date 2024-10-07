using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LG_Assignment.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
