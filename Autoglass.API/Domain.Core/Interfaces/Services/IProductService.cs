using Autoglass.API.Infra.Filter;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;

namespace Autoglass.API.Domain.Core.Interfaces.Services;
public interface IProductService
{
    Task<BaseResponse> CreateProductAsync(RequestCreateProductDto dto, CancellationToken cancellationToken = default);
    Task<BaseResponse<ResponseReadProductDto>> DisableProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<BaseResponse<ResponseReadProductDto>> EditProductByIdAsync(int id, RequestUpdateProductDto dto, CancellationToken cancellationToken = default);
    Task<BasePagedResponse<IEnumerable<ResponseReadProductDto>>> GetAllProductsAsync(PaginationFilter filter, CancellationToken cancellationToken = default);
    Task<BaseResponse<ResponseReadProductDto>> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
}