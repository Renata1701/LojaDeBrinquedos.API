using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loja.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransportadoraController : ControllerBase
{
    public string Id { get; set; }


}
