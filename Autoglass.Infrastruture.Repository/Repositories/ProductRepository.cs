using Autoglass.Domain.Core.Repositories;
using Autoglass.Domain.Models;
using Autoglass.Infrastructure.Data.Context;
using System.Linq.Expressions;

namespace Autoglass.Infrastruture.Repository.Repositories;

public class ProductRepository : BaseRepository<AutoglassContext, Product>, IProductRepository
{
    public ProductRepository(AutoglassContext context) : base(context)
    {
    }

    public async Task<int> AddProduct(Product entity)
    {
        return await Add(entity);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await GetAllAsync();
    }

    public async Task<Product> GetByIdProductAsync(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetByProductConditionAsync(Expression<Func<Product, bool>> predicate)
    {
        return await GetWhereAsync(predicate);
    }

    public async Task<int> RemoveProduct(Product entity, string propertyName)
    {
        return await Remove(entity, propertyName);
    }

    public async Task<int> UpdateProduct(Product entity, string[] propertysName)
    {
        return await Update(entity, propertysName);
    }
}
