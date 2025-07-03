using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LojaDeBrinquedos2.Db_Context
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private string _connectionString;

        public TesteController()
        {
            _connectionString = "Server=localhost;Port=3306;Database=seu_banco;User ID=root;Password=;SslMode=none;";

        }

        [HttpGet("conexao")]
        public IActionResult Teste()
        {
            string connectionString = "Server=localhost;Port=3306;Database=lojadebrinquedos;Uid=root;Pwd= ;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return Ok("Conexão aberta com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao conectar: " + ex.Message);
                }
            }
        }
    }
}
