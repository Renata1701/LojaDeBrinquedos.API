namespace LojaDeBrinquedos2.Classes;

public class Funcionarios
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Cargo { get; set; }
    public required string Salário { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required string DataAdmissão { get; set; }
    public Funcionarios(string Nome, string Cpf, string Cargo, string Salário, string Email, string Telefone, string DataAdmissão) 
    { 
        this.Nome = Nome;
        this.Cpf = Cpf;
        this.Cargo = Cargo;
        this.Salário = Salário;
        this.Email = Email;
        this.Telefone = Telefone;
        this.DataAdmissão = DataAdmissão;
    }

}
