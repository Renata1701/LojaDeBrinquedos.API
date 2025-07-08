using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private static readonly List<PedidoController> _pedidos = new()
    {
        new PedidoController
        {
            Id = 1,
            IdCliente = 1,
            DataPedido = DateTime.Now.AddDays(-5),
            Status = "Pago",
            FormaPagamento = "Cartão",
            ValorTotal = 150.00m
        },
        new PedidoController
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
    public DateTime DataPedido { get; set; }
    public required string Status { get; set; }
    public required string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }

    [HttpGet]
    public ActionResult<IEnumerable<PedidoController>> ObterTodos()
    {
        return Ok(_pedidos);
    }

    [HttpGet("{id}")]
    public ActionResult<PedidoController> ObterPorId(int id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound(new { mensagem = "Pedido não encontrado." });

        return Ok(pedido);
    }


    [HttpPost]
    public ActionResult<PedidoController> Criar([FromBody] PedidoCreateDto novoDto)
    {
        var novoPedido = new PedidoController
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






