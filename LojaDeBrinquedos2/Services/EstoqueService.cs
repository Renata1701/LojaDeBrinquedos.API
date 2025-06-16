namespace LojaDeBrinquedos2.Services;

public class EstoqueService
{
    private readonly List<Estoque> _estoques = new();

    public IEnumerable<Estoque> GetAll() => _estoques;

    public Estoque GetById(int id)
    {
        return _estoques.FirstOrDefault(e => e.Id == id);
    }

    public Estoque Create(Estoque estoque)
    {
        estoque.Id = _estoques.Count + 1;
        _estoques.Add(estoque);
        return estoque;
    }

    public Estoque? Update(int id, Estoque estoque)
    {
        var existing = _estoques.FirstOrDefault(e => e.Id == id);
        if (existing == null) return null;

        existing.ProdutoId = estoque.ProdutoId;
        existing.QuantidadeDisponivel = estoque.QuantidadeDisponivel;
        existing.Localizacao = estoque.Localizacao;

        return existing;
    }

    public bool Delete(int id)
    {
        var estoque = _estoques.FirstOrDefault(e => e.Id == id);
        if (estoque == null) return false;
        _estoques.Remove(estoque);
        return true;
    }
}






