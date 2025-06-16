using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Frete : ControllerBase
{
    private static List<Frete> _fretes = new()
    {
        new Frete
        {
            Id = 1,
            IdEntrega = 1,
            Valor = 28.50m,
            PrazoEstimado = 5,
            TipoEnvio = "PAC"
        }
    };

    public required object IdEntrega { get; set; }
    public required object Valor { get; set; }
    public required object PrazoEstimado { get; set; }
    public required object TipoEnvio { get;set; }
    public int Id { get;set; }

  
    [HttpGet]
    public ActionResult<IEnumerable<Frete>> ObterTodos()
    {
        return Ok(_fretes);
    }


    [HttpGet("{id}")]
    public ActionResult<Frete> ObterPorId(int id)
    {
        var frete = _fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null)
            return NotFound(new { mensagem = "Frete não encontrado." });

        return Ok(frete);
    }

   
    [HttpPost]
    public ActionResult<Frete> Criar([FromBody] Frete novo)
    {
        novo.Id = _fretes.Any() ? _fretes.Max(f => f.Id) + 1 : 1;
        _fretes.Add(novo);

        return CreatedAtAction(nameof(ObterPorId), new { id = novo.Id }, novo);
    }

 
    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Frete atualizado)
    {
        var frete = _fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null)
            return NotFound(new { mensagem = "Frete não encontrado." });

        frete.IdEntrega = atualizado.IdEntrega;
        frete.Valor = atualizado.Valor;
        frete.PrazoEstimado = atualizado.PrazoEstimado;
        frete.TipoEnvio = atualizado.TipoEnvio;

        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var frete = _fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null)
            return NotFound(new { mensagem = "Frete não encontrado." });

        _fretes.Remove(frete);
        return NoContent();
    }
}




