using Autoglass.API.Infra.Filter;
using Autoglass.API.Infra.Helper;
using Autoglass.API.Infra.Repositories;
using Autoglass.API.Services.Interfaces;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;
using Oceanica.GupyProd.Shared.Base;

namespace Autoglass.API.Services;

public class ProductService : IProductService
{
    private IProductRepository ProductRepository;
    private IUriService UriService;
    private IHttpContextAccessor HttpContextAccessor;

    public ProductService(IProductRepository productRepository, IUriService uriService, IHttpContextAccessor httpContextAccessor)
    {
        ProductRepository = productRepository;
        UriService = uriService;
        HttpContextAccessor = httpContextAccessor;
    }

    public async Task<BasePagedResponse<IEnumerable<ResponseReadProductDto>>> GetAllProductsAsync(PaginationFilter filter, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var route = GetCurrentUrl(HttpContextAccessor.HttpContext.Request);

        var products = await ProductRepository.GetAllProductsAsync();

        var productList = PaginationHelper.PagedData(filter, products);

        var response = productList.Select(p => new ResponseReadProductDto().MapToDto(p));

        var pagedResponse = PaginationHelper.CreatePagedReponse(response, filter, productList.Count(), UriService, route);

        return pagedResponse;
    }

    public async Task<BaseResponse> CreateProductAsync(RequestCreateProdutoDto dto, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = dto.MapToEntity(dto);

        var result = await ProductRepository.AddProduct(product);

        return new BaseResponse
        {
            Errors = new List<BaseResponseError>(),
        };
    }

    private string GetCurrentUrl(HttpRequest request)
    {
        return request.Path + request.QueryString;
    }
}
