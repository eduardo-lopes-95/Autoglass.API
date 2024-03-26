using Autoglass.API.Infra.Filter;
using Autoglass.API.Services;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Oceanica.GupyProd.Shared.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Autoglass.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : BaseController
{
    public IProductService Product { get; set; }

    public ProductController(IProductService product)
    {
        Product = product;
    }

    /// <summary>
    /// Create new product
    /// </summary>
    [HttpPost("create")]
    [SwaggerResponse(201, Type = typeof(BaseResponse<ResponseReadProductDto>))]
    [SwaggerResponse(400, Type = typeof(BaseResponse))]
    public async Task<IActionResult> CreateProductAsync([FromBody] RequestCreateProductDto request, CancellationToken cancellationToken)
    {
        var response = await Product.CreateProductAsync(request);
        return Response(response, !response.Success ? HttpStatusCode.BadRequest : HttpStatusCode.Created);
    }

    /// <summary>
    /// List all products
    /// </summary>
    [HttpPost("list-products")]
    [SwaggerResponse(200, Type = typeof(BasePagedResponse<IEnumerable<ResponseReadProductDto>>))]
    [SwaggerResponse(400, Type = typeof(BaseResponse))]
    public async Task<IActionResult> CreateProductAsync([FromBody] PaginationFilter filter, CancellationToken cancellationToken)
    {
        var response = await Product.GetAllProductsAsync(filter, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
    }

    /// <summary>
    /// Return product by Id
    /// </summary>
    [HttpGet("{id}")]
    [SwaggerResponse(200, Type = typeof(BaseResponse<ResponseReadProductDto>))]
    [SwaggerResponse(400, Type = typeof(BaseResponse))]
    public async Task<IActionResult> CreateProductAsync(int id, CancellationToken cancellationToken)
    {
        var response = await Product.GetProductByIdAsync(id, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
    }

    /// <summary>
    /// Edit product by Id
    /// </summary>
    [HttpPut("edit-product/{id}")]
    [SwaggerResponse(200, Type = typeof(BaseResponse<ResponseReadProductDto>))]
    [SwaggerResponse(400, Type = typeof(BaseResponse))]
    public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] RequestUpdateProductDto request, CancellationToken cancellationToken)
    {
        var response = await Product.EditProductByIdAsync(id, request, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
    }

    /// <summary>
    /// Disable product by Id
    /// </summary>
    [HttpDelete("disable-product/{id}")]
    [SwaggerResponse(200, Type = typeof(BaseResponse<ResponseReadProductDto>))]
    [SwaggerResponse(400, Type = typeof(BaseResponse))]
    public async Task<IActionResult> RemoveProductAsync(int id, CancellationToken cancellationToken)
    {
        var response = await Product.DisableProductByIdAsync(id, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
    }
}
