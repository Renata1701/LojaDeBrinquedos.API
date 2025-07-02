using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private static readonly List<ClienteController> _clientes = new()
    {
        new ClienteController
        {
            Id = 1,
            Nome = "Ana Pereira",
            CPF = "111.222.333-44",
            Email = "ana.pereira@email.com",
            Telefone = "31988889999",
            Endereco = "Rua das Flores, 10 - Centro",
            DataCadastro = DateTime.Now.AddDays(-12)
        },
        new ClienteController
        {
            Id = 2,
            Nome = "Bruno Costa",
            CPF = "222.333.444-55",
            Email = "bruno.costa@email.com",
            Telefone = "31999998888",
            Endereco = "Av. Brasil, 555 - Bairro Novo",
            DataCadastro = DateTime.Now.AddDays(-7)
        },
        new ClienteController
        {
            Id = 3,
            Nome = "Cláudia Lima",
            CPF = "333.444.555-66",
            Email = "claudia.lima@email.com",
            Telefone = "31997776666",
            Endereco = "Rua Azul, 89 - Bairro Antigo",
            DataCadastro = DateTime.Now.AddDays(-3)
        }
    };

    public int Id { get; set; }
    public required string Nome { get;set; }
    public required string CPF { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get;set; }
    public required string Endereco { get;  set; }
    public DateTime DataCadastro { get; set; }

    [HttpGet]
    public ActionResult<IEnumerable<ClienteController>> ObterTodos()
    {
        return Ok(_clientes);
    }

    [HttpGet("{id}")]
    public ActionResult<ClienteController> ObterPorId(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        return Ok(cliente);
    }

    [HttpPost]
    public ActionResult<ClienteController> Criar([FromBody] ClienteController novo)
    {
        novo.Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
        novo.DataCadastro = DateTime.Now;
        _clientes.Add(novo);
        return CreatedAtAction(nameof(ObterPorId), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] ClienteController atualizado)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        cliente.Nome = atualizado.Nome;
        cliente.CPF = atualizado.CPF;
        cliente.Email = atualizado.Email;
        cliente.Telefone = atualizado.Telefone;
        cliente.Endereco = atualizado.Endereco;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return NotFound(new { mensagem = "Cliente não encontrado." });

        _clientes.Remove(cliente);
        return NoContent();
    }
}





