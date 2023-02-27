using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Models;

namespace WorkSchedule.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(string id);
        Task<T> Get(string id);
        IEnumerable<T> AsEnumerable(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        Task SaveChanges();
    }
}
