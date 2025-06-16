namespace LojaDeBrinquedos2.Services;

public class ItensCompradosService
{

    private readonly List<ItensCompradosService> _itens = new();

    public required object ProdutoId { get;  set; }
    public required object Quantidade { get;  set; }
    public required object PrecoUnitario { get;  set; }
    public int Id { get; private set; }

    public IEnumerable<ItensCompradosService> GetAll() => _itens;

    public ItensCompradosService GetById(int id)
    {
        return _itens.FirstOrDefault(i => i.Id == id);
    }

    public ItensCompradosService Create(ItensCompradosService item)
    {
        item.Id = _itens.Count + 1;
        _itens.Add(item);
        return item;
    }

    public ItensCompradosService? Update(int id, ItensCompradosService item)
    {
        var existing = _itens.FirstOrDefault(i => i.Id == id);
        if (existing == null) return null;

        existing.ProdutoId = item.ProdutoId;
        existing.Quantidade = item.Quantidade;
        existing.PrecoUnitario = item.PrecoUnitario;

        return existing;
    }

    public bool Delete(int id)
    {
        var item = _itens.FirstOrDefault(i => i.Id == id);
        if (item == null) return false;
        _itens.Remove(item);
        return true;
    }
}





