using Autoglass.API.Infra.Filter;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;
using Oceanica.GupyProd.Shared.Base;

namespace Autoglass.API.Services;
public interface IProductService
{
    Task<BaseResponse> CreateProductAsync(RequestCreateProdutoDto dto, CancellationToken cancellationToken = default);
    Task<BasePagedResponse<IEnumerable<ResponseReadProductDto>>> GetAllProductsAsync(PaginationFilter filter, CancellationToken cancellationToken = default);
}