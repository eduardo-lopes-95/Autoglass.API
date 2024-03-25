using Autoglass.API.Infra.Filter;
using Autoglass.API.Infra.Helper;
using Autoglass.API.Infra.Repositories;
using Autoglass.API.Models;
using Autoglass.API.Shared;
using Oceanica.GupyProd.Shared.Base;

namespace Autoglass.API.Services;

public class ProductService
{
    private IProductRepository ProductRepository;

    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public async Task<BasePagedResponse<IEnumerable<ResponseReadProductDto>>> GetAllProductsAsync(PaginationFilter filter, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var products = await ProductRepository.GetAllProductsAsync();
        
        var productList = PaginationHelper.PagedData(filter, products);

        var response = productList.Select(p => ResponseReadProductDto);

        return pagedResponse;
    }

    
}
