using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PagamentoController : ControllerBase
{
    private static readonly List<PagamentoController> _pagamentos = new()
    {
        new PagamentoController
        {
            Id = 1,
            IdPedido = 1,
            TipoPagamento = "Pix",
            Status = "Aprovado",
            DataPagamento = DateTime.Now.AddDays(-3),
            Valor = 150.00m
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<PagamentoController>> ObterTodos()
    {
        return Ok(_pagamentos);
    }


    [HttpGet("{id}")]
    public ActionResult<PagamentoController> ObterPorId(int id)
    {
        var pagamento = _pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null)
            return NotFound(new { mensagem = "Pagamento não encontrado." });

        return Ok(pagamento);
    }


    [HttpPost]
    public ActionResult<PagamentoController> Criar([FromBody] PagamentoCreateDto novoPagamento)
    {
        var pagamento = new PagamentoController
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





