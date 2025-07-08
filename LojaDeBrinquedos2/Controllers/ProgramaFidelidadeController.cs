using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProgramaFidelidadeController : ControllerBase
{
    private static List<ClienteFidelidade> clientesFidelidade = new List<ClienteFidelidade>
    {
        new ClienteFidelidade(1, "João Silva", 120),
        new ClienteFidelidade(2, "Maria Oliveira", 85),
    };

    public class ClienteFidelidade
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public int Pontos { get; set; }

        public ClienteFidelidade(int clienteId, string nome, int pontos)
        {
            ClienteId = clienteId;
            Nome = nome;
            Pontos = pontos;
        }
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(clientesFidelidade);
    }


    [HttpGet("{clienteId}")]
    public IActionResult BuscarPorCliente(int clienteId)
    {
        var cliente = clientesFidelidade.FirstOrDefault(c => c.ClienteId == clienteId);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        return Ok(cliente);
    }


    [HttpPost("adicionar-pontos")]
    public IActionResult AdicionarPontos([FromQuery] int clienteId, [FromQuery] int pontos)
    {
        var cliente = clientesFidelidade.FirstOrDefault(c => c.ClienteId == clienteId);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        if (pontos <= 0)
            return BadRequest(new { mensagem = "Pontos devem ser positivos." });

        cliente.Pontos += pontos;
        return Ok(cliente);
    }


    [HttpPost("remover-pontos")]
    public IActionResult RemoverPontos([FromQuery] int clienteId, [FromQuery] int pontos)
    {
        var cliente = clientesFidelidade.FirstOrDefault(c => c.ClienteId == clienteId);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        if (pontos <= 0)
            return BadRequest(new { mensagem = "Pontos devem ser positivos." });

        if (cliente.Pontos < pontos)
            return BadRequest(new { mensagem = "Saldo insuficiente de pontos." });

        cliente.Pontos -= pontos;
        return Ok(cliente);
    }


    [HttpGet("acima-de/{pontosMinimos}")]
    public IActionResult ListarClientesComPontosMinimos(int pontosMinimos)
    {
        var clientes = clientesFidelidade.Where(c => c.Pontos >= pontosMinimos).ToList();
        return Ok(clientes);
    }


    [HttpPost("trocar-pontos")]
    public IActionResult TrocarPontos([FromQuery] int clienteId, [FromQuery] int pontos)
    {
        var cliente = clientesFidelidade.FirstOrDefault(c => c.ClienteId == clienteId);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        if (pontos <= 0)
            return BadRequest(new { mensagem = "Pontos devem ser positivos." });

        if (cliente.Pontos < pontos)
            return BadRequest(new { mensagem = "Saldo insuficiente para troca." });

        cliente.Pontos -= pontos;


        string recompensa = "Desconto de 10% na próxima compra";

        return Ok(new
        {
            mensagem = $"Pontos trocados por: {recompensa}",
            saldoRestante = cliente.Pontos
        });
    }
}