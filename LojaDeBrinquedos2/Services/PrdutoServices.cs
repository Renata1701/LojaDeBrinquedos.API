namespace LojaDeBrinquedos2.Services;
public class ProdutoService
{
    private readonly List<Produto> _produtos = new();

    public IEnumerable<Produto> GetAll() => _produtos;

    public Produto GetById(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Create(Produto produto)
    {
        produto.Id = _produtos.Count + 1;
        _produtos.Add(produto);
        return produto;
    }

    public Produto? Update(int id, Produto produto)
    {
        var existing = _produtos.FirstOrDefault(p => p.Id == id);
        if (existing == null) return null;

        existing.Nome = produto.Nome;
        existing.Descricao = produto.Descricao;
        existing.Preco = produto.Preco;
        existing.Marca = produto.Marca;
        existing.CategoriaId = produto.CategoriaId;
        existing.CodigoBarras = produto.CodigoBarras;
        existing.ImagemUrl = produto.ImagemUrl;

        return existing;
    }

    public bool Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return false;
        _produtos.Remove(produto);
        return true;
    }
}






