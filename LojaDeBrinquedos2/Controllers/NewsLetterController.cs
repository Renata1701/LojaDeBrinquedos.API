using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NewsLetterController : ControllerBase
{

    private static List<NewsLetterController> _inscritos = new();
    private static int _proximoId = 1;

    public string? Email { get; private set; }
    public int Id { get; private set; }

    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(_inscritos);
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody] NewsLetterController novo)
    {
        if (string.IsNullOrWhiteSpace(novo.Email))
            return BadRequest("Email é obrigatório.");

        if (_inscritos.Any(i => i.Email.Equals(novo.Email, StringComparison.CurrentCultureIgnoreCase)))
            return Conflict("Email já cadastrado.");

        novo.Id = _proximoId++;
        _inscritos.Add(novo);

        return CreatedAtAction(nameof(GetTodos), new { id = novo.Id }, novo);
    }


    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
        var inscrito = _inscritos.FirstOrDefault(i => i.Id == id);
        if (inscrito == null)
            return NotFound();

        _inscritos.Remove(inscrito);
        return NoContent();
    }
}








