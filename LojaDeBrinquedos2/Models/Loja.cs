namespace LojaDeBrinquedos2.Classes;

public class Loja
{
 public required string Nome {  get; set; }
    public required string Cnpj { get; set; }
    public required string Endereco { get; set; }
    public required string Telefone { get; set; }
    public required string Responsavel { get; set; }
      
    public Loja(string Nome, string Cnpj, string Endereco, string Telefone, string Responsavel) 
    { 
     this.Nome = Nome;
     this.Cnpj = Cnpj;
     this.Endereco = Endereco;
     this.Telefone = Telefone;
     this.Responsavel = Responsavel;
    
    }



}
