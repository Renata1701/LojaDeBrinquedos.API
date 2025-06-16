using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItensComprados : ControllerBase
{
    private static readonly List<ItensComprados> _itensComprados = new();

    public int Id { get;  set; }
    public required string PedidoId { get; set; }
    public required object ProdutoId { get; set; }
    public required object Quantidade { get; set; }
    public required object PrecoUnitario { get; set; }

    
    [HttpGet]
    public ActionResult<IEnumerable<ItensComprados>> GetAll()
    {
        return Ok(_itensComprados);
    }

    
    [HttpGet("{id}")]
    public ActionResult<ItensComprados> GetById(int id)
    {
        var item = _itensComprados.FirstOrDefault(i => i.Id == id);
        if (item == null) return NotFound();

        return Ok(item);
    }

    
    [HttpPost]
    public ActionResult<ItensComprados> Create(ItensComprados novoItem)
    {
        novoItem.Id = _itensComprados.Any() ? _itensComprados.Max(i => i.Id) + 1 : 1;
        _itensComprados.Add(novoItem);
        return CreatedAtAction(nameof(GetById), new { id = novoItem.Id }, novoItem);
    }

   
    [HttpPut("{id}")]
    public IActionResult Update(int id, ItensComprados itemAtualizado)
    {
        var existente = _itensComprados.FirstOrDefault(i => i.Id == id);
        if (existente == null) return NotFound();

        existente.PedidoId = itemAtualizado.PedidoId;
        existente.ProdutoId = itemAtualizado.ProdutoId;
        existente.Quantidade = itemAtualizado.Quantidade;
        existente.PrecoUnitario = itemAtualizado.PrecoUnitario;

        return NoContent();
    }



}
