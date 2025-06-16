using System.Runtime.InteropServices;
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }
    public string ImagemUrl { get; set; }
    public string CodigoBarras { get; set; }
    public object Marca { get; internal set; }
    public object CategoriaId { get; internal set; }

    public Produto(int id, string nome, string descricao, decimal preco, string categoria, string imagemUrl, string codigoBarras)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Categoria = categoria;
        ImagemUrl = imagemUrl;
        CodigoBarras = codigoBarras;
    }

}

