namespace LojaDeBrinquedos2.Classes;

public class Transportadora(string nome, string telefone, string email, string cnpj)
{
    public required string Nome { get; set; } = nome;
    public required string Telefone { get; set; } = telefone;
    public required string Email { get; set; } = email;
    public required string Cnpj { get; set; } = cnpj;
    public required ICollection<Entrega> Entregas { get; set; }
}
