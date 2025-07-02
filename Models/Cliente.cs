namespace LojadeBrinquedos_api.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }

        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }

        public ICollection<Pedido> Itens { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

        public Cliente(int id, int clienteId, Cliente cliente, DateTime dataPedido, string status, string formaPagamento, decimal valorTotal)
        {
            Id = id;
            ClienteId = clienteId;
            this.cliente = cliente;
            DataPedido = dataPedido;
            Status = status;
            FormaPagamento = formaPagamento;
            ValorTotal = valorTotal;
        }

        public class Pagamento
        {
            public int Id { get; set; }
            public int PedidoId { get; set; }
            public Pedido Pedido { get; set; }
            public string MetodoPagamento { get; set; }
            public decimal ValorPago { get; set; }
            public DateTime DataPagamento { get; set; }
            public Pagamento(int id, int pedidoId, Pedido pedido, string metodoPagamento, decimal valorPago, DateTime dataPagamento)
            {
                Id = id;
                PedidoId = pedidoId;
                Pedido = pedido;
                MetodoPagamento = metodoPagamento;
                ValorPago = valorPago;
                DataPagamento = dataPagamento;
            }
        }
        public class Pedido
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public Cliente cliente { get; set; }
            public DateTime DataPedido { get; set; }
            public string Status { get; set; }
            public string FormaPagamento { get; set; }
            public decimal ValorTotal { get; set; }
            public ICollection<Pedido> Itens { get; set; }
        }



    }
}
