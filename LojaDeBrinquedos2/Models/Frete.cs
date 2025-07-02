namespace LojaDeBrinquedos2.Classes;

public class Frete
{
    public required string Entrega {  get; set; }
    public required string Valor { get; set; }
    public required string Prazo { get; set; }
   
    public required string TipoEnvio { get; set; }

    public Frete(string Entrega, string Valor, string Prazo, string TipoEnvio) 
    { 
     this.Entrega = Entrega;
     this.Valor = Valor;
     this.Prazo = Prazo;
     this.TipoEnvio = TipoEnvio;
    }
}
