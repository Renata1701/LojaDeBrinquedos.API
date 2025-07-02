namespace LojadeBrinquedos_api.Models
{
    public class ItemPedido
    {
        public string Id { get; set; }

        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public ItemPedido(string id, string nomeProduto, string descricaoProduto, decimal valorUnitario, int quantidade, decimal valorTotal)
        {
            Id = id;
            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }
        public ProdutoController.Produto Produto { get; set; }






    }
}
