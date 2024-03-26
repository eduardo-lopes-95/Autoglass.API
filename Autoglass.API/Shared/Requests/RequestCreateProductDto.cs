using Autoglass.API.Models;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Shared.Requests;

/// <summary>
/// Data Transfer Object (DTO) para criação de um novo produto.
/// </summary>
public class RequestCreateProductDto : BaseDto<RequestCreateProductDto, Product>
{
    /// <summary>
    /// Obtém ou define o código do produto.
    /// </summary>
    /// <example>12345</example>
    public int CodigoProduto { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do produto.
    /// </summary>
    /// <example>Produto A</example>
    public string? DescricaoProduto { get; set; }

    /// <summary>
    /// Obtém ou define a situação do produto.
    /// </summary>
    /// <example>Inativo</example>
    public string SituacaoProduto { get; set; }

    /// <summary>
    /// Obtém ou define a data de fabricação do produto.
    /// </summary>
    /// <example>2024-03-26 08:30:00</example>
    public DateTime DataFabricacao { get; set; }

    /// <summary>
    /// Obtém ou define a data de validade do produto.
    /// </summary>
    /// <example>2024-03-26 08:30:00</example>
    public DateTime DataValidade { get; set; }

    /// <summary>
    /// Obtém ou define o código do fornecedor do produto.
    /// </summary>
    /// <example>9876</example>
    public int CodigoFornecedor { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do fornecedor do produto.
    /// </summary>
    /// <example>Fornecedor XYZ</example>
    public string DescricaoFornecedor { get; set; }

    /// <summary>
    /// Obtém ou define o CNPJ do fornecedor do produto.
    /// </summary>
    /// <example>12345678000190</example>
    public string CNPJFornecedor { get; set; }
}

