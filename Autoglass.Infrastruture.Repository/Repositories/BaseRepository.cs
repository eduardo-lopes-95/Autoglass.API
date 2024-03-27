using Autoglass.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Autoglass.Infrastruture.Repository.Repositories;

public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
    where TContext : DbContext
    where TEntity : class
{
    protected TContext Context;

    protected BaseRepository(TContext context)
    {
        Context = context;
    }

    public async Task<int> Add(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        return await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<int> Remove(TEntity entity, string propertyName)
    {
        Edit(entity, propertyName);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> Update(TEntity entity, string[] propertysName)
    {
        if (propertysName != null && propertysName.Any())
        {
            foreach (var property in propertysName)
                Edit(entity, property);
        }
        return await Context.SaveChangesAsync();
    }

    private void Edit(TEntity entity, string propertyName)
    {
        Context.Entry(entity).Property(propertyName).IsModified = true;
    }
}
