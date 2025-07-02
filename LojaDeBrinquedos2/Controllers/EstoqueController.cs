using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstoqueController : ControllerBase
{
    public static List<EstoqueController> estoques = new List<EstoqueController> 
    {
        new EstoqueController("Carrinho de Controle Remoto", 50, "Prateleira A1"),
        new EstoqueController("Boneca Fashion", 30, "Prateleira B2"),
        new EstoqueController("Quebra-Cabeça 1000 Peças", 20, "Prateleira C3")
    };


    private string NomeProduto;
    public int Quantidade;
    public string Localizacao;
    private int v1;
    private string v2;
    private int v3;

    public EstoqueController(string nomeProduto, int quantidade, string localizacao)
    {
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        Localizacao = localizacao;
    }

    public EstoqueController(int v1, string v2, int v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    [HttpGet] 
public IActionResult Get()
    {
        return Ok(estoques);
    }
    [HttpGet("{Produto}")]
    public IActionResult Get(string nomeProduto)
    {
        var estoque = estoques.FirstOrDefault(e => e.NomeProduto == nomeProduto);
        if (estoque == null) return NotFound();
        return Ok(estoque);
    }
    [HttpPost]
    public IActionResult Post([FromBody] EstoqueController estoque)
    {

        estoques.Add(estoque);
        return CreatedAtAction(nameof(Get), new { nomeProduto = estoque.NomeProduto }, estoque);
    }
    [HttpPut("{nomeProduto}")]
    public IActionResult Put(string nomeProduto, [FromBody] EstoqueController estoque)
    {
        var index = estoques.FindIndex(e => e.NomeProduto == nomeProduto);
        if (index == -1) return NotFound();
        estoques[index] = estoque;
        return NoContent();
    }
    [HttpDelete("{nomeProduto}")]
    public IActionResult Delete(string nomeProduto)
    {
        var index = estoques.FindIndex(e => e.NomeProduto == nomeProduto);
        if (index == -1) return NotFound();
        estoques.RemoveAt(index);
        return NoContent();
    }
}

