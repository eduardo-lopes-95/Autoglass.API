using Autoglass.API.Infra.Filter;
using Autoglass.API.Services;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductAsync([FromBody] RequestCreateProductDto request, CancellationToken cancellationToken)
    {
        var response = await Product.CreateProductAsync(request);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }

    [HttpPost("list-products")]
    public async Task<IActionResult> CreateProductAsync([FromBody] PaginationFilter filter, CancellationToken cancellationToken)
    {
        var response = await Product.GetAllProductsAsync(filter, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> CreateProductAsync(int id, CancellationToken cancellationToken)
    {
        var response = await Product.GetProductByIdAsync(id, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }

    [HttpPut("edit-product/{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] RequestUpdateProductDto request, CancellationToken cancellationToken)
    {
        var response = await Product.EditProductByIdAsync(id, request, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }

    [HttpDelete("disable-product/{id}")]
    public async Task<IActionResult> RemoveProductAsync(int id, CancellationToken cancellationToken)
    {
        var response = await Product.DisableProductByIdAsync(id, cancellationToken);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }
}
