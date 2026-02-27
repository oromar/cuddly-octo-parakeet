using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.Models;
using System.Linq.Expressions;

namespace Shared.Repositories
{
    public class BaseRepository<T>(DbContext context) : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext context = context;

        public async Task<T> Add(T entity)
        {
            await context.AddAsync(entity);
            CreateSearchText(entity);
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

        public async Task Delete(string id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                context.Remove(entity);
            }
        }

        public async Task<T> Get(string id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            context.Update(entity);
            CreateSearchText(entity);
            return entity;
        }

        private static void CreateSearchText(T entity)
        {
            if (entity is ITextSearcheable searcheable)
            {
                searcheable.CreateSearchText();
            }
        }
    }
}
