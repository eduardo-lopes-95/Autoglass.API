using Autoglass.API.Domain.Models;
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
    /// <summary>
    /// Obtém ou define a data de fabricação do produto.
    /// </summary>
    /// <example>2024-03-26T08:30:00</example>
    public DateTime DataFabricacao { get; set; }

    /// <summary>
    /// Obtém ou define a data de validade do produto.
    /// </summary>
    /// <example>2024-03-26T08:30:00</example>
    public DateTime DataValidade { get; set; }
}
