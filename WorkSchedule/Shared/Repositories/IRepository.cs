using Shared.Entities;
using System.Linq.Expressions;

namespace Shared.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T?> GetAsync(string id);
    IEnumerable<T> AsEnumerable(Expression<Func<T, bool>> predicate);
    IQueryable<T> AsQueryable();
    Task SaveChangesAsync();
}
