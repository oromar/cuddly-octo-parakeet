using System.Linq.Expressions;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;
using WorkSchedule.Infra.Context;

namespace WorkSchedule.Infra.Repositories
{
    public class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly WorkScheduleContext context;

        public BaseRepository(WorkScheduleContext context)
        {
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
            context.Add(entity);
            return entity;
        }

        public IEnumerable<T> AsEnumerable(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).AsEnumerable();
        }

        public IQueryable<T> AsQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        public Task Delete(string id)
        {
            var entity = Get(id);
            if (entity != null)
                context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> Get(string id)
        {
            return context.Set<T>().FirstOrDefault(a => a.Id == id);
        }

        public async Task SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task<T> Update(T entity)
        {
            context.Update(entity);
            return entity;
        }
    }
}
