namespace LojaDeBrinquedos2.Classes;

public class CompraEstoque
{
    public required string Fornecedor { get; set; }
    public required string DataCompra {  get; set; }
    public required string NotaFiscal { get; set; }
    public required string ValorTotal { get; set; }
    public ICollection<ItensComprados> Itens { get; set; }
    public CompraEstoque(string Fornecedor, string DataCompra, string NotaFiscal, string ValorTotal)
    {
        this.Fornecedor = Fornecedor;
        this.DataCompra = DataCompra;
        this.NotaFiscal = NotaFiscal;
        this.ValorTotal = ValorTotal;

    }

        


}

