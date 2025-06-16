using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Transportadora : ControllerBase
{
    private static List<Transportadora> _transportadoras = new()
    {
        new Transportadora
        {
            Id = 1,
            Nome = "TransBrinquedos LTDA",
            CNPJ = "12.345.678/0001-90",
            Contato = "João da Silva",
            Telefone = "(31) 91234-5678",
            Email = "contato@transbrinquedos.com"
        }
    };

    public int Id { get; set; }
    public required string Nome { get; set; }
    public required object CNPJ { get; set; }
    public required object Contato { get;  set; }
    public required object Telefone { get; set; }
    public required object Email { get;  set; }

    [HttpGet]
    public ActionResult<IEnumerable<Transportadora>> ObterTodas()
    {
        return Ok(_transportadoras);
    }

    [HttpGet("{id}")]
    public ActionResult<Transportadora> ObterPorId(int id)
    {
        var transportadora = _transportadoras.FirstOrDefault(t => t.Id == id);
        if (transportadora == null)
            return NotFound(new { mensagem = "Transportadora não encontrada." });

        return Ok(transportadora);
    }

  
    [HttpPost]
    public ActionResult<Transportadora> Criar([FromBody] Transportadora nova)
    {
        nova.Id = _transportadoras.Any() ? _transportadoras.Max(t => t.Id) + 1 : 1;
        _transportadoras.Add(nova);

        return CreatedAtAction(nameof(ObterPorId), new { id = nova.Id }, nova);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Transportadora atualizada)
    {
        var transportadora = _transportadoras.FirstOrDefault(t => t.Id == id);
        if (transportadora == null)
            return NotFound(new { mensagem = "Transportadora não encontrada." });

        transportadora.Nome = atualizada.Nome;
        transportadora.CNPJ = atualizada.CNPJ;
        transportadora.Contato = atualizada.Contato;
        transportadora.Telefone = atualizada.Telefone;
        transportadora.Email = atualizada.Email;

        return NoContent();
    }

 
    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var transportadora = _transportadoras.FirstOrDefault(t => t.Id == id);
        if (transportadora == null)
            return NotFound(new { mensagem = "Transportadora não encontrada." });

        _transportadoras.Remove(transportadora);
        return NoContent();
    }
}








