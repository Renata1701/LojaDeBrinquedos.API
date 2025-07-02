using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace loja.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstoqueController : ControllerBase
{
    public ProdutosController ProdutosController { get; set; }
    public int Quantidade { get; set; }
    public string Localização { get; set; }
    public EstoqueController(ProdutosController produto, int quantidade, string localização)
    {
        ProdutosController = produto;
        Quantidade = quantidade;
        Localização = localização;
    }

    public int Id { get; set; }
    public FornecedorController Fornecedor { get; set; }
    public DateTime DataCompra { get; set; }
    public string NotaFiscal { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ProdutosController> Produtos { get; set; }

    public EstoqueController(FornecedorController fornecedor, DateTime dataCompra, string notaFiscal, decimal valorTotal, List<ProdutosController> produtos)
    {
        Fornecedor = fornecedor;
        DataCompra = dataCompra;
        NotaFiscal = notaFiscal;
        ValorTotal = valorTotal;
        Produtos = produtos;
    }



}
