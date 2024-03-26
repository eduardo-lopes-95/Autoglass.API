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

    [HttpPost("Product/create")]
    public async Task<IActionResult> CreateProductAsync([FromBody] RequestCreateProdutoDto request, CancellationToken cancellationToken)
    {
        var response = await Product.CreateProductAsync(request);
        return Response(response, !response.Success ? HttpStatusCode.Unauthorized : HttpStatusCode.Created);
    }
}
