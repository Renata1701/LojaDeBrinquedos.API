namespace LojaDeBrinquedos2.Classes;

public class CupomDeDesocnto
{
    public required string Codigo { get; set; }
    public required string Tipo { get; set; }
public required string Valor { get; set; }
    public required string Validade { get; set; }
    public required string Status { get; set; }

    public CupomDeDesocnto(string Codigo, string Tipo, string Valor, string Validade, string Status)
    { 
        this.Codigo = Codigo;
        this.Tipo = Tipo;
        this.Valor = Valor;
        this.Validade = Validade;
        this.Status = Status;
    
    
    
    }



}
