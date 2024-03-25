namespace Autoglass.API.Models;

public class Product
{
    public int CodigoProduto { get; set; }

    public string DescricaoProduto { get; set; }

    public bool SituacaoProduto { get; set; }

    public DateTime DataFabricacao { get; set; }

    public DateTime DataValidade { get; set; }

    public int CodigoFornecedor { get; set; }

    public string DescricaoFornecedor { get; set; }

    public string CNPJFornecedor { get; set; }

    public Product()
    {
        SituacaoProduto = true;
    }

    public string ObterStatus()
    {
        return SituacaoProduto ? "Ativo" : "Inativo";
    }
}
