namespace LojadeBrinquedos_api.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int QuantidadeDisponivel { get; set; }
        public string Localizacao { get; set; }
        public Estoque(int id, int produtoId, Produto produto, int quantidadeDisponivel, string localizacao)
        {
            Id = id;
            ProdutoId = produtoId;
            Produto = produto;
            QuantidadeDisponivel = quantidadeDisponivel;
            Localizacao = localizacao;
        }








    }
}
