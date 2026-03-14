using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.Entities;
using System.Linq.Expressions;

namespace Shared.Repositories;

public class BaseRepository<T>(DbContext context) : IRepository<T> where T : BaseEntity
{
    private readonly DbContext context = context;

    public async Task<T> AddAsync(T entity)
    {
        CreateSearchText(entity);
        await context.AddAsync(entity);
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

    public async Task DeleteAsync(string id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            context.Remove(entity);
        }
    }

    public async Task<T?> GetAsync(string id)
    {
        return await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        CreateSearchText(entity);
        await Task.Run(() => context.Update(entity));
        return entity;
    }

    private static void CreateSearchText(T entity)
    {
        if (entity is ITextSearcheable searcheable)
            searcheable.CreateSearchText();
    }
}
