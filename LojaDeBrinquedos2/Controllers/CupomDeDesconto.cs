using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CupomDeDesconto(int v1, string v2, int v3, bool v4, DateTime dateTime, bool v5) : ControllerBase
{
    private static List<CupomDeDesconto> cupons = new List<CupomDeDesconto>
    {
        new CupomDeDesconto(1, "DESCONTO10", 10, true, DateTime.Now.AddDays(30), true),
        new CupomDeDesconto(2, "FRETEGRATIS", 20, false, DateTime.Now.AddDays(10), true)
    };

    public object? Codigo { get;  set; }
    public object?ValorDesconto { get; set; }
    public object? Percentual { get;  set; }
    public object? ValidoAte { get;  set; }
    public object? Ativo { get;  set; }
    public int Id { get; set; }
    public int V1 { get; } = v1;
    public string V2 { get; } = v2;
    public int V3 { get; } = v3;
    public bool V4 { get; } = v4;
    public DateTime DateTime { get; } = dateTime;
    public bool V5 { get; } = v5;

    
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(cupons);
    }

   
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null)
            return NotFound(new { mensagem = "Cupom não encontrado." });

        return Ok(cupom);
    }

    
    [HttpPost]
    public IActionResult Criar([FromBody] CupomDeDesconto novo)
    {
        novo.Id = cupons.Count > 0 ? cupons.Max(c => c.Id) + 1 : 1;
        cupons.Add(novo);
        return CreatedAtAction(nameof(BuscarPorId), new { id = novo.Id }, novo);
    }

   
    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] CupomDeDesconto atualizado)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null)
            return NotFound(new { mensagem = "Cupom não encontrado." });

        cupom.Codigo = atualizado.Codigo;
        cupom.ValorDesconto = atualizado.ValorDesconto;
        cupom.Percentual = atualizado.Percentual;
        cupom.ValidoAte = atualizado.ValidoAte;
        cupom.Ativo = atualizado.Ativo;

        return Ok(cupom);
    }

  
    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null)
            return NotFound(new { mensagem = "Cupom não encontrado." });

        cupons.Remove(cupom);
        return NoContent();
    }
}






