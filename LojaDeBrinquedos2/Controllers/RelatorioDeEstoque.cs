using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RelatorioDeEstoque : ControllerBase
{ 
      public int ProdutoId { get; set; }
    public string NomeProduto { get; set; }
    public int Quantidade { get; set; }

    public RelatorioDeEstoque(int produtoId, string nomeProduto, int quantidade)
    {
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
    }
    


    private static List<Estoque> _estoques = new()
    {
            new Estoque(1, "Carrinho Controle Remoto", 15),
            new Estoque(2, "Boneca Fashion", 3),
            new Estoque(3, "Jogo Educativo", 0),
            new Estoque(4, "Pista Hot Wheels", 20),
    };

    [HttpGet]
    public IActionResult EstoqueAtual()
    {
        return Ok(_estoques);
    }

  
    [HttpGet("baixo")]
    public IActionResult EstoqueBaixo([FromQuery] int limite = 5)
    {
        var produtosBaixos = _estoques.Where(e => e.Quantidade <= limite).ToList();
        return Ok(produtosBaixos);
    }

    [HttpGet("zerado")]
    public IActionResult EstoqueZerado()
    {
        var zerados = _estoques.Where(e => e.Quantidade == 0).ToList();
        return Ok(zerados);
    }
}


   





