namespace LojaDeBrinquedos2.Services;

public class FreteService
{

    private readonly List<FreteService> _fretes = new();
    private int Id;

    public required object EntregaId { get; set; }
    public required object Valor { get;  set; }
    public required object PrazoEstimado { get;  set; }
    public required object TipoEnvio { get;  set; }

    public IEnumerable<FreteService> GetAll() => _fretes;

    public FreteService GetById(int id)
    {
        return _fretes.FirstOrDefault(f => f.Id == id);
    }

    public FreteService Create(FreteService frete)
    {
        frete.Id = _fretes.Count + 1;
        _fretes.Add(frete);
        return frete;
    }

    public FreteService Update(int id, FreteService frete)
    {
        var existing = _fretes.FirstOrDefault(f => f.Id == id);
        if (existing == null) return null;

        existing.EntregaId = frete.EntregaId;
        existing.Valor = frete.Valor;
        existing.PrazoEstimado = frete.PrazoEstimado;
        existing.TipoEnvio = frete.TipoEnvio;

        return existing;
    }

   
}
