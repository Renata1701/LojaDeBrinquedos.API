using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private static List<FuncionariosController> _funcionarios = new()
    {
        new FuncionariosController
        {
            Id = 1,
            Nome = "Ana Souza",
            CPF = "123.456.789-00",
            Cargo = "Gerente",
            Salario = 3200m,
            Email = "ana.souza@lojabrinquedos.com",
            Telefone = "(31) 99876-5432",
            DataAdmissao = new DateTime(2022, 5, 10)
        }
    };

    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get;  set; }
    public required string Cargo { get; set; }
    public decimal Salario { get; set; }
    public required string Email { get;  set; }
    public required string Telefone { get;  set; }
    public DateTime DataAdmissao { get; set; }

  
    [HttpGet]
    public ActionResult<IEnumerable<FuncionariosController>> ObterTodos()
    {
        return Ok(_funcionarios);
    }

   
    [HttpGet("{id}")]
    public ActionResult<FuncionariosController> ObterPorId(int id)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null)
            return NotFound(new { mensagem = "Funcionário não encontrado." });

        return Ok(funcionario);
    }

    [HttpPost]
    public ActionResult<FuncionariosController> Criar([FromBody] FuncionariosController novo)
    {
        novo.Id = _funcionarios.Any() ? _funcionarios.Max(f => f.Id) + 1 : 1;
        _funcionarios.Add(novo);

        return CreatedAtAction(nameof(ObterPorId), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] FuncionariosController atualizado)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null)
            return NotFound(new { mensagem = "Funcionário não encontrado." });

        funcionario.Nome = atualizado.Nome;
        funcionario.CPF = atualizado.CPF;
        funcionario.Cargo = atualizado.Cargo;
        funcionario.Salario = atualizado.Salario;
        funcionario.Email = atualizado.Email;
        funcionario.Telefone = atualizado.Telefone;
        funcionario.DataAdmissao = atualizado.DataAdmissao;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null)
            return NotFound(new { mensagem = "Funcionário não encontrado." });

        _funcionarios.Remove(funcionario);
        return NoContent();
    }
}







