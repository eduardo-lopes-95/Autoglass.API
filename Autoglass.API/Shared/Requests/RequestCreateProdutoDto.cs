using Autoglass.API.Models;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Shared.Requests;

public class RequestCreateProdutoDto : BaseDto<RequestCreateProdutoDto, Product>
{
    public int CodigoProduto { get; set; }

    public string? DescricaoProduto { get; set; }

    public bool SituacaoProduto { get; set; }

    public DateTime DataFabricacao { get; set; }

    public DateTime DataValidade { get; set; }

    public int CodigoFornecedor { get; set; }

    public string DescricaoFornecedor { get; set; }

    public string CNPJFornecedor { get; set; }
}
