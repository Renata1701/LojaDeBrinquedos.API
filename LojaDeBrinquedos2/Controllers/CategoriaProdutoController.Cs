using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriaProduto : ControllerBase
  
{
    private static List<CategoriaProduto> categorias = new List<CategoriaProduto>
    {
        new CategoriaProduto { Id = 1, Nome = "Jogos de Tabuleiro", Tipo = "Educativo" },
        new CategoriaProduto { Id = 2, Nome = "Carrinhos", Tipo = "Veículo" },
        new CategoriaProduto { Id = 3, Nome = "Massinhas", Tipo = "Criativo" }
    };

    public int Id { get; private set; }
    public required string Nome { get;  set; }
    public string? Tipo { get; private set; }

   
    [HttpGet]
    public IActionResult ListarCategorias()
    {
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult ObterCategoria(int id)
    {
        var categoria = categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null)
            return NotFound(new { mensagem = "Categoria não encontrada." });

        return Ok(categoria);
    }

    
    [HttpPost]
    public IActionResult CriarCategoria([FromBody] CategoriaProduto novaCategoria)
    {
        novaCategoria.Id = categorias.Count > 0 ? categorias.Max(c => c.Id) + 1 : 1;
        categorias.Add(novaCategoria);
        return CreatedAtAction(nameof(ObterCategoria), new { id = novaCategoria.Id }, novaCategoria);
    }

   
    [HttpPut("{id}")]
    public IActionResult AtualizarCategoria(int id, [FromBody] CategoriaProduto categoriaAtualizada)
    {
        var categoria = categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null)
            return NotFound(new { mensagem = "Categoria não encontrada para atualização." });

        categoria.Nome = categoriaAtualizada.Nome;
        categoria.Tipo = categoriaAtualizada.Tipo;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirCategoria(int id)
    {
     var categoria = categorias.FirstOrDefault(c => c.Id == id);
      if (categoria == null)
      return NotFound(new { mensagem = "Categoria não encontrada para exclusão." });

        categorias.Remove(categoria);
        return NoContent();
    }
}

    




