using Autoglass.API.Models;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Shared.Responses;

public class ResponseReadProductDto : BaseDto<ResponseReadProductDto, Product>
{
    public int Id { get; set; }

    public int CodigoProduto { get; set; }

    public string? DescricaoProduto { get; set; }

    public string SituacaoProduto { get; set; }

    public DateTime DataFabricacao { get; set; }

    public DateTime DataValidade { get; set; }

    public int CodigoFornecedor { get; set; }

    public string DescricaoFornecedor { get; set; }

    public string CNPJFornecedor { get; set; }
}
