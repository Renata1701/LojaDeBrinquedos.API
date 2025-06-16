namespace LojaDeBrinquedos2.Classes;

public class Pedido
{
    public string Id { get; set; }
    public string Data { get; set; }
    public string ClienteId { get; set; }
    public string Status { get; set; }  
    public string TipoPagamento { get; set; }
    public string ValorTotal { get; set; }
    public ICollection<ItensComprados> Itens { get; set; }

    public Pedido(string id, string data, string clienteId, string status, string tipoPagamento, string valorTotal)
    {
        Id = id;
        Data = data;
        ClienteId = clienteId;
        Status = status;
        TipoPagamento = tipoPagamento;
        ValorTotal = valorTotal;
    }



}
