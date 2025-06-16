namespace LojaDeBrinquedos2.Services;

public class FornecedorService
{
    private readonly List<FornecedorService> _fornecedores = new();
    private object? Endereco;

    public required object Nome { get; set; }
    public required object CNPJ { get; set; }
    public required object Contato { get; set; }
    public required object Email { get;  set; }
    public required object Telefone { get;  set; }
    public int Id { get;  set; }

    public IEnumerable<FornecedorService> GetAll() => _fornecedores;

    public FornecedorService GetById(int id)
    {
        return _fornecedores.FirstOrDefault(f => f.Id == id);
    }

    public FornecedorService Create(FornecedorService fornecedor)
    {
        fornecedor.Id = _fornecedores.Count + 1;
        _fornecedores.Add(fornecedor);
        return fornecedor;
    }

    public FornecedorService Update(int id, FornecedorService fornecedor)
    {
        var existing = _fornecedores.FirstOrDefault(f => f.Id == id);
        if (existing == null) return null;

        existing.Nome = fornecedor.Nome;
        existing.CNPJ = fornecedor.CNPJ;
        existing.Contato = fornecedor.Contato;
        existing.Endereco = fornecedor.Endereco;
        existing.Email = fornecedor.Email;
        existing.Telefone = fornecedor.Telefone;

        return existing;
    }

    public bool Delete(int id)
    {
        var fornecedor = _fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null) return false;
        _fornecedores.Remove(fornecedor);
        return true;
    }
}



