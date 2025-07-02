using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loja.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase
{
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public FornecedorController(string nome, string cnpj, string telefone, string email)

    {
        Nome = nome;
        CNPJ = cnpj;
        Telefone = telefone;
        Email = email;
    }

}
