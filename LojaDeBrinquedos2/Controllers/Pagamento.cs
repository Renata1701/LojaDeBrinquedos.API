using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Pagamento : ControllerBase
{
    private static readonly List<Pagamento> _pagamentos = new()
    {
        new Pagamento
        {
            Id = 1,
            IdPedido = 1,
            TipoPagamento = "Pix",
            Status = "Aprovado",
            DataPagamento = DateTime.Now.AddDays(-3),
            Valor = 150.00m
        }
    };

    public int Id { get; set; }
    public int IdPedido { get; set; }
    public required string TipoPagamento { get;set; }
    public required string Status { get; set; }
    public DateTime DataPagamento { get; set; }
    public decimal Valor { get; set; }

    
    [HttpGet]
    public ActionResult<IEnumerable<Pagamento>> ObterTodos()
    {
        return Ok(_pagamentos);
    }

   
    [HttpGet("{id}")]
    public ActionResult<Pagamento> ObterPorId(int id)
    {
        var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null)
            return NotFound(new { mensagem = "Pagamento não encontrado." });

        return Ok(pagamento);
    }

   
    [HttpPost]
    public ActionResult<Pagamento> Criar([FromBody] PagamentoCreateDto novoPagamento)
    {
        var pagamento = new Pagamento
        {
            Id = _pagamentos.Any() ? _pagamentos.Max(p => p.Id) + 1 : 1,
            IdPedido = novoPagamento.IdPedido,
            TipoPagamento = novoPagamento.TipoPagamento,
            Status = "Pendente",
            DataPagamento = DateTime.Now,
            Valor = novoPagamento.Valor
        };

        _pagamentos.Add(pagamento);
        return CreatedAtAction(nameof(ObterPorId), new { id = pagamento.Id }, pagamento);
    }

  
    [HttpPut("{id}")]
    public IActionResult AtualizarStatus(int id, [FromBody] string novoStatus)
    {
        var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null)
            return NotFound(new { mensagem = "Pagamento não encontrado." });

        pagamento.Status = novoStatus;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null)
            return NotFound(new { mensagem = "Pagamento não encontrado." });

        _pagamentos.Remove(pagamento);
        return NoContent();
    }

    public class PagamentoCreateDto
    {
        public required string TipoPagamento { get; set; }
        public int IdPedido { get; set; }
        public decimal Valor { get; set; }
    }
}





