using Autoglass.API.Models;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Shared.Requests;

public class RequestUpdateProductDto : BaseDto<RequestUpdateProductDto, Product>
{
    public string DescricaoProduto { get; set; }
    public string SituacaoProduto { get; set; }
}
