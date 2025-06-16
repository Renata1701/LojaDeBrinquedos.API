namespace LojaDeBrinquedos2.Services;

public class CompraEstoqueService
{

    private readonly List<CompraEstoqueService> _compras = new();

    public int Id { get; private set; }
    public required object FornecedorId { get; set; }
    public required object DataCompra { get; set; }
    public required object NotaFiscal { get;  set; }
    public required object ValorTotal { get; set; }

    public IEnumerable<CompraEstoqueService> GetAll() => _compras;

    public CompraEstoqueService GetById(int id)
    {
        return _compras.FirstOrDefault(c => c.Id == id);
    }

    public CompraEstoqueService Create(CompraEstoqueService compra)
    {
        compra.Id = _compras.Count + 1;
        _compras.Add(compra);
        return compra;
    }

    public CompraEstoqueService Update(int id, CompraEstoqueService compra)
    {
        var existing = _compras.FirstOrDefault(c => c.Id == id);
        if (existing == null) return null;

        existing.FornecedorId = compra.FornecedorId;
        existing.DataCompra = compra.DataCompra;
        existing.NotaFiscal = compra.NotaFiscal;
        existing.ValorTotal = compra.ValorTotal;

        return existing;
    }

    public bool Delete(int id)
    {
        var compra = _compras.FirstOrDefault(c => c.Id == id);
        if (compra == null) return false;
        _compras.Remove(compra);
        return true;
    }
}

