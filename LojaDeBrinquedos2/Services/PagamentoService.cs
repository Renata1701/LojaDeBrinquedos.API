namespace LojaDeBrinquedos2.Services;

public class PagamentoService
{

    private readonly List<PagamentoService> _pagamentos = new();
    private int Id;

    public required object PedidoId { get;  set; }
    public required object TipoPagamento { get;  set; }
    public required object Status { get;  set; }
    public required object DataPagamento { get; set; }
    public required object Valor { get;  set; }

    public IEnumerable<PagamentoService> GetAll() => _pagamentos;

    public PagamentoService GetById(int id)
    {
        return _pagamentos.FirstOrDefault(p =>p.Id == id);
    }

    public PagamentoService Create(PagamentoService pagamento)
    {
        pagamento.Id = _pagamentos.Count + 1;
        _pagamentos.Add(pagamento);
        return pagamento;
    }

    public PagamentoService Update(int id, PagamentoService pagamento)
    {
        var existing = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (existing == null) return null;

        existing.PedidoId = pagamento.PedidoId;
        existing.TipoPagamento = pagamento.TipoPagamento;
        existing.Status = pagamento.Status;
        existing.DataPagamento = pagamento.DataPagamento;
        existing.Valor = pagamento.Valor;

        return existing;
    }

    public bool Delete(int id)
    {
        var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null) return false;
        _pagamentos.Remove(pagamento);
        return true;
    }
}

