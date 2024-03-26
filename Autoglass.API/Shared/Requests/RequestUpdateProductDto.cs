using Autoglass.API.Models;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Shared.Requests;

public class RequestUpdateProductDto : BaseDto<RequestUpdateProductDto, Product>
{
    /// <summary>
    /// Obtém ou define a descrição do produto.
    /// </summary>
    /// <example>Produto A</example>
    public string DescricaoProduto { get; set; } = string.Empty;

    /// <summary>
    /// Obtém ou define a situação do produto.
    /// </summary>
    /// <example>Ativo</example>
    public string SituacaoProduto { get; set; } = string.Empty;
}
