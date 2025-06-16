using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Pedido : ControllerBase
{
    private static readonly List<Pedido> _pedidos = new()
    {
        new Pedido
        {
            Id = 1,
            IdCliente = 1,
            DataPedido = DateTime.Now.AddDays(-5),
            Status = "Pago",
            FormaPagamento = "Cartão",
            ValorTotal = 150.00m
        },
        new Pedido
        {
            Id = 2,
            IdCliente = 2,
            DataPedido = DateTime.Now.AddDays(-2),
            Status = "Pendente",
            FormaPagamento = "Pix",
            ValorTotal = 89.90m
        }
    };

    public int Id { get; private set; }
    public int IdCliente { get; set; }
    public DateTime DataPedido { get;set; }
    public required string Status { get; set; }
    public required string FormaPagamento { get;set; }
    public decimal ValorTotal { get; set; }

    [HttpGet]
    public ActionResult<IEnumerable<Pedido>> ObterTodos()
    {
        return Ok(_pedidos);
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> ObterPorId(int id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound(new { mensagem = "Pedido não encontrado." });

        return Ok(pedido);
    }

    
    [HttpPost]
    public ActionResult<Pedido> Criar([FromBody] PedidoCreateDto novoDto)
    {
        var novoPedido = new Pedido
        {
            Id = _pedidos.Any() ? _pedidos.Max(p => p.Id) + 1 : 1,
            IdCliente = novoDto.IdCliente,
            DataPedido = DateTime.Now,
            Status = "Pendente",
            FormaPagamento = novoDto.FormaPagamento,
            ValorTotal = novoDto.ValorTotal
        };

        _pedidos.Add(novoPedido);
        return CreatedAtAction(nameof(ObterPorId), new { id = novoPedido.Id }, novoPedido);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarStatus(int id, [FromBody] string novoStatus)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound(new { mensagem = "Pedido não encontrado." });

        pedido.Status = novoStatus;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound(new { mensagem = "Pedido não encontrado." });

        _pedidos.Remove(pedido);
        return NoContent();
    }

    public class PedidoCreateDto
    {
        public int IdCliente { get; internal set; }
        public required string FormaPagamento { get; set; }
        public decimal ValorTotal { get; internal set; }
    }
}






