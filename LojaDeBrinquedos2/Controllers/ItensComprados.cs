using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItensComprados : ControllerBase
{
    public static  List<ItensComprados> comprados;
    private int Id;
    private int ProdutoId;
    private int Quantidade;
    private int PrecoUnitario;

    [HttpGet]
    public ActionResult Lista(string id)
    {
        return Ok(comprados);
    }

    [HttpGet("{id}")]
    public ActionResult ListaPorId(int id)
    {
        var item = comprados.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { mensagem = "Item não encontrado." });
        }
        return Ok(item);
    }

    [HttpPost]

    public ActionResult AdicionarItem([FromBody] ItensComprados item)
    {
        if (item == null || item.ProdutoId <= 0 || item.Quantidade <= 0 || item.PrecoUnitario <= 0)
        {
            return BadRequest(new { mensagem = "Dados do item são inválidos." });
        }
        item.Id = comprados.Count > 0 ? comprados.Max(i => i.Id) + 1 : 1;
        comprados.Add(item);
        return CreatedAtAction(nameof(ListaPorId), new { id = item.Id }, item);
    }

    [HttpPost]

    public ActionResult AdicionarVariosItens([FromBody] List<ItensComprados> itens)
    {
        if (itens == null || !itens.Any())
        {
            return BadRequest(new { mensagem = "Lista de itens é inválida." });
        }
        foreach (var item in itens)
        {
            if (item.ProdutoId <= 0 || item.Quantidade <= 0 || item.PrecoUnitario <= 0)
            {
                return BadRequest(new { mensagem = "Dados de um ou mais itens são inválidos." });
            }
            item.Id = comprados.Count > 0 ? comprados.Max(i => i.Id) + 1 : 1;
            comprados.Add(item);
        }
        return Ok(itens);
    }

    [HttpPut("{id}")]

    public ActionResult AtualizarItem(int id, [FromBody] ItensComprados itemAtualizado)
    {
        var item = comprados.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { mensagem = "Item não encontrado para atualização." });
        }
        item.ProdutoId = itemAtualizado.ProdutoId;
        item.Quantidade = itemAtualizado.Quantidade;
        item.PrecoUnitario = itemAtualizado.PrecoUnitario;
        return Ok(item);
    }

    [HttpDelete("{id}")]

    public ActionResult DeletarItem(int id)
    {
        var item = comprados.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { mensagem = "Item não encontrado." });
        }
        comprados.Remove(item);
        return NoContent();
    }
}