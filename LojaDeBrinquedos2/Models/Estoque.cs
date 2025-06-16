using System.Runtime.InteropServices;

public class  Estoque
{
    public string NomeProduto { get; set; }
    public int Quantidade { get; set; }
    public string Localizacao { get; set; }
    public object ProdutoId { get; internal set; }
    public object QuantidadeDisponivel { get; internal set; }
    public int Id { get; internal set; }

    public Estoque(string nomeProduto, int quantidade, string localizacao)
    {
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        Localizacao = localizacao;
    }
}

