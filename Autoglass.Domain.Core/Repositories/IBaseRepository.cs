using System.Linq.Expressions;

namespace Autoglass.API.Shared.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> Add(TEntity entity);
    Task<int> Update(TEntity entity, string[] propertysName);
    Task<int> Remove(TEntity entity, string propertyName);
}