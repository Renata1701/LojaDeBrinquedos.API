using System.Runtime.InteropServices;

public class CategoriaProduto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; }
    public CategoriaProduto(int id, string nome, string descricao, string imagemUrl)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        ImagemUrl = imagemUrl;
    }
}
