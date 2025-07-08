using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LojaController : ControllerBase
{
    public static List<LojaController> _lojas = new()
    {
        new LojaController
        {
            Id = 1,
            Nome = "Loja Brinquedos Felizes",
            CNPJ = "12.345.678/0001-99",
            Endereco = "Rua das Crianças, 123 - Centro",
            Telefone = "(31) 3232-2323",
            Responsavel = "Renata Oliveira"
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<LojaController>> ObterTodas()
    {
        return Ok(_lojas);
    }

    [HttpGet("{id}")]
    public ActionResult<LojaController> ObterPorId(int id)
    {
        var loja = _lojas.FirstOrDefault(l => l.Id == id);
        if (loja == null)
            return NotFound(new { mensagem = "Loja não encontrada." });

        return Ok(loja);
    }

    [HttpPost]
    public ActionResult<LojaController> Criar([FromBody] LojaController nova)
    {
        nova.Id = _lojas.Any() ? _lojas.Max(l => l.Id) + 1 : 1;
        _lojas.Add(nova);
        return CreatedAtAction(nameof(ObterPorId), new { id = nova.Id }, nova);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] LojaController atualizada)
    {
        var loja = _lojas.FirstOrDefault(l => l.Id == id);
        if (loja == null)
            return NotFound(new { mensagem = "Loja não encontrada." });

        loja.Nome = atualizada.Nome;
        loja.CNPJ = atualizada.CNPJ;
        loja.Endereco = atualizada.Endereco;
        loja.Telefone = atualizada.Telefone;
        loja.Responsavel = atualizada.Responsavel;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var loja = _lojas.FirstOrDefault(l => l.Id == id);
        if (loja == null)
            return NotFound(new { mensagem = "Loja não encontrada." });

        _lojas.Remove(loja);
        return NoContent();
    }
}



