namespace LojadeBrinquedos_api.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataDoPedido { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public Pedido(int id, int clienteId, DateTime dataDoPedido, string status, string formaPagamento, decimal valorTotal, ICollection<ItemPedido> itens)
        {
            Id = id;
            ClienteId = clienteId;
            DataDoPedido = dataDoPedido;
            Status = status;
            FormaPagamento = formaPagamento;
            ValorTotal = valorTotal;
            Itens = itens;
        }

        public ICollection<ItemPedido> Itens { get; set; }





    }
}
