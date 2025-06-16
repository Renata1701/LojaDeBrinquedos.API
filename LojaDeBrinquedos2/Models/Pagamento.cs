namespace LojaDeBrinquedos2.Classes;

public class Pagamento
{
    public string Pedido { get; set; }
    public string TipoPagamento { get; set; }
    public string Status { get; set; }
    public string Data { get; set; }
    public string ValorTotal { get; set; }

    public Pagamento(string Pedido, string TipoPagamento, string Status, string Data, string ValorTotal)
    {
     this.Pedido = Pedido;
    this.TipoPagamento = TipoPagamento;
    this.Status = Status;
    this.Data = Data;
    this.ValorTotal = ValorTotal;
    
    
    }






}
