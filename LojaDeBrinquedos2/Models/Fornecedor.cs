namespace LojaDeBrinquedos2.Classes;

public class Fornecedor
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public ICollection<CompraEstoque> Compras { get; set; } = new List<CompraEstoque>();
    public Fornecedor(string nome, string cnpj, string email, string telefone, string endereco)
    {
        Nome = nome;
        Cnpj = cnpj;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }



}
