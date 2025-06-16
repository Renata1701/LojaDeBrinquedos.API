using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>
    {
        new Produto(1, "Carrinho de Controle Remoto", "Carrinho de controle remoto com bateria recarregável", 150.00m, "Brinquedos Eletrônicos", "https://example.com/carrinho.jpg", "1234567890123"),
        new Produto(2, "Boneca Fashion", "Boneca com roupas e acessórios modernos", 80.00m, "Brinquedos de Bonecas", "https://example.com/boneca.jpg", "1234567890124"),
        new Produto(3, "Quebra-Cabeça 1000 Peças", "Quebra-cabeça desafiador com imagem de Sistema Solar", 50.00m, "Jogos de Tabuleiro", "https://example.com/quebra-cabeca.jpg", "1234567890125")
    };

    private static int nextId = produtos.Max(p => p.Id) + 1;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Produto produto)
    {
        produto.Id = nextId++;
        produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produto)
    {
        var index = produtos.FindIndex(p => p.Id == id);
        if (index == -1) return NotFound();

        produto.Id = id;
        produtos[index] = produto;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();

        produtos.Remove(produto);
        return NoContent();
    }
}


