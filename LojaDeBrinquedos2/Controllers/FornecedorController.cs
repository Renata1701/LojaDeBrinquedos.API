using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers.Produtos;
[Route("api/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase
{
    private static List<FornecedorController> fornecedores = new List<FornecedorController>
        {
            new FornecedorController { Id = 1, Nome = "Fornecedor A", Cnpj = "12345678000100", Telefone = "(31) 99999-9999", Email = "contato@fornecedora.com" }
        };

    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? Cnpj { get; private set; }
    public string? Telefone { get; private set; }
    public string? Email { get; private set; }

    [HttpGet]
    public IActionResult ListarFornecedores()
    {
        return Ok(fornecedores);
    }

    [HttpGet("{id}")]
    public IActionResult ObterFornecedor(int id)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null)
            return NotFound(new { mensagem = "Fornecedor não encontrado." });

        return Ok(fornecedor);
    }

    [HttpPost]
    public IActionResult CriarFornecedor([FromBody] FornecedorController novoFornecedor)
    {
        if (novoFornecedor == null || string.IsNullOrWhiteSpace(novoFornecedor.Nome))
            return BadRequest(new { mensagem = "Dados do fornecedor são inválidos." });

        novoFornecedor.Id = fornecedores.Count > 0 ? fornecedores.Max(f => f.Id) + 1 : 1;
        fornecedores.Add(novoFornecedor);

        return CreatedAtAction(nameof(ObterFornecedor), new { id = novoFornecedor.Id }, novoFornecedor); // ✅ Isso está certo
    }



    [HttpPut("{id}")]
    public IActionResult AtualizarFornecedor(int id, [FromBody] FornecedorController fornecedorAtualizado)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null)
            return NotFound(new { mensagem = "Fornecedor não encontrado para atualização." });

        fornecedor.Nome = fornecedorAtualizado.Nome;
        fornecedor.Cnpj = fornecedorAtualizado.Cnpj;
        fornecedor.Telefone = fornecedorAtualizado.Telefone;
        fornecedor.Email = fornecedorAtualizado.Email;

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult ExcluirFornecedor(int id)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null)
            return NotFound(new { mensagem = "Fornecedor não encontrado." });

        fornecedores.Remove(fornecedor);
        return NoContent();
    }
}



