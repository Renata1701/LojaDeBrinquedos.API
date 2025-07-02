namespace LojaDeBrinquedos2.Classes;

public class ItensComprados
{
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
  
    public ItensComprados (int Id, int ProdutoId,int Quantidade, decimal PrecoUnitario) 
    {
        this.Id = Id;
        this.ProdutoId = ProdutoId;
        this.Quantidade = Quantidade;
        this.PrecoUnitario = PrecoUnitario;
    }
}
