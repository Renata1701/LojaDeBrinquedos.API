namespace LojaDeBrinquedos2.Classes;

public class Cliente(string Nome, string Cpf, string Email, string Telefone, string Endereco, string DataCadastro)
{
    public string Nome { get; set; } = Nome;
    public string Cpf { get; set; } = Cpf;
    public string Email { get; set; } = Email;
    public string Telefone { get; set; } = Telefone;
    public string Endereco { get; set; } = Endereco;
    public string DataCadastro { get; set; } = DataCadastro;
    public int Id { get; internal set; }
    public required string CPF { get;  set; }
    public required ICollection<Pedido> Pedidos { get; set; }
}
