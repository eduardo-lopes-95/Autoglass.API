using Autoglass.API.Models;
using System.Linq.Expressions;

namespace Autoglass.Domain.Core.Repositories;
public interface IProductRepository
{
    Task<int> AddProduct(Product entity);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetByIdProductAsync(int id);
    Task<IEnumerable<Product>> GetByProductConditionAsync(Expression<Func<Product, bool>> predicate);
    Task<int> RemoveProduct(Product entity, string propertyName);
    Task<int> UpdateProduct(Product entity, string[] propertysName);
}