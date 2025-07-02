using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntregaController : ControllerBase
{
    private static List<EntregaController> _entregas = new()
    {
        new EntregaController
        {
            Id = 1,
            IdPedido = 1,
            IdTransportadora = 1,
            Status = "Enviado",
            CodigoRastreio = "BR123456789",
            DataEnvio = DateTime.Now.AddDays(-2),
            DataEntrega = null
        }
    };

    public int Id { get; private set; }
    public required string Status { get; set; }
    public required object? DataEnvio { get;  set; }
    public required object? DataEntrega { get; set; }
    public int IdPedido { get; set; }
    public int IdTransportadora { get; set; }
    public required string CodigoRastreio { get; set; }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_entregas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entrega = _entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null)
            return NotFound(new { mensagem = "Entrega não encontrada." });

        return Ok(entrega);
    }

    [HttpPost]
    public IActionResult Create([FromBody] EntregaController novaEntrega)
    {
        novaEntrega.Id = _entregas.Any() ? _entregas.Max(e => e.Id) + 1 : 1;
        novaEntrega.Status = "Pendente";
        novaEntrega.DataEnvio = null;
        novaEntrega.DataEntrega = null;

        _entregas.Add(novaEntrega);
        return CreatedAtAction(nameof(GetById), new { id = novaEntrega.Id }, novaEntrega);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStatus(int id, [FromBody] string novoStatus)
    {
        var entrega = _entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null)
            return NotFound(new { mensagem = "Entrega não encontrada." });

        entrega.Status = novoStatus;

        if (novoStatus.ToLower() == "enviado")
        {
            entrega.DataEnvio = DateTime.Now;
        }

        if (novoStatus.ToLower() == "entregue")
        {
            entrega.DataEntrega = DateTime.Now;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entrega = _entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null)
            return NotFound(new { mensagem = "Entrega não encontrada." });

        _entregas.Remove(entrega);
        return NoContent();
    }
}




