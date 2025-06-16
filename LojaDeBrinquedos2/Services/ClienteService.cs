namespace LojaDeBrinquedos2.Services;

public class ClienteService
{
    private readonly List<ClienteService> _clientes = new();

    public int Id { get;  set; }
    public required object Nome { get;  set; }
    public required object CPF { get; set; }
    public required object Email { get; set; }
    public required object Telefone { get;  set; }
    public required object Endereco { get;set; }
    public required object DataCadastro { get; set; }

    public IEnumerable<ClienteService> GetAll() => _clientes;

    public ClienteService GetById(int id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public ClienteService Create(ClienteService cliente)
    {
        cliente.Id = _clientes.Count + 1;
        _clientes.Add(cliente);
        return cliente;
    }

    public ClienteService Update(int id, ClienteService cliente)
    {
        var existing = _clientes.FirstOrDefault(c => c.Id == id);
        if (existing == null) return null;

        existing.Nome = cliente.Nome;
        existing.CPF = cliente.CPF;
        existing.Email = cliente.Email;
        existing.Telefone = cliente.Telefone;
        existing.Endereco = cliente.Endereco;
        existing.DataCadastro = cliente.DataCadastro;

        return existing;
    }

    public bool Delete(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null) return false;
        _clientes.Remove(cliente);
        return true;
    }
}





