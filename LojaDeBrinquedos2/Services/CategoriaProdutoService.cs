namespace LojaDeBrinquedos2.Services;


public class  CategoriaProdutoService
{
    private readonly List<CategoriaProduto> _categorias = new();

    public IEnumerable<CategoriaProduto> GetAll() => _categorias;

    public CategoriaProduto GetById(int id)
    {
        return _categorias.FirstOrDefault(c => c.Id == id);
    }
    public CategoriaProduto Create(CategoriaProduto categoria)
    {
        categoria.Id = _categorias.Count + 1;
        _categorias.Add(categoria);
        return categoria;
    }

    public CategoriaProduto? Update(int id, CategoriaProduto categoria)
    {
        var existing = _categorias.FirstOrDefault(c => c.Id == id);
        if (existing == null) return null;

        existing.Nome = categoria.Nome;
        existing.Descricao = categoria.Descricao;

        return existing;
    }

    public bool Delete(int id)
    {
        var categoria = _categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null) return false;
        _categorias.Remove(categoria);
        return true;
    }
}






