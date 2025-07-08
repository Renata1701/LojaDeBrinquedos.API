using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItensCompradosController : ControllerBase
{
    private static readonly List<ItensCompradosController> _itensComprados = new();

    [HttpGet]
    public ActionResult<IEnumerable<ItensCompradosController>> GetAll()
    {
        return Ok(_itensComprados);
    }

    [HttpGet("{id}")]
    public ActionResult<ItensCompradosController> GetById(int id)
    {
        var item = _itensComprados.FirstOrDefault(i => i.Id == id);
        if (item == null) return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public ActionResult<ItensCompradosController> Create(ItensCompradosController novoItem)
    {
        novoItem.Id = _itensComprados.Any() ? _itensComprados.Max(i => i.Id) + 1 : 1;
        _itensComprados.Add(novoItem);
        return CreatedAtAction(nameof(GetById), new { id = novoItem.Id }, novoItem);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ItensCompradosController itemAtualizado)
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
