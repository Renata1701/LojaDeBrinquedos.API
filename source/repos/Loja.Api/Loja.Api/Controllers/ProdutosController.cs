using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loja.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }
    public string Marca { get; set; }
    public string Imagem { get; set; }
    public ProdutosController(string nome, string descricao, decimal preco, string categoria, string marca, string imagem)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Categoria = categoria;
        Marca = marca;
        Imagem = imagem;
    }
} 

