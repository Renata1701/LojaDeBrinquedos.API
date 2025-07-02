using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LojaDeBrinquedos2.Db_Context
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly Database _db;

        public TesteController(Database db)
        {
            _db = db;
        }

       
        [HttpGet("conexao")]
        public IActionResult VerificarConexao()
        {
            if (_db.TestarConexao())
                return Ok("Conexão com o banco de dados feita com sucesso!");
            else
                return StatusCode(500, "Erro ao conectar com o banco de dados.");
        }

        
        [HttpGet("categorias")]
        public IActionResult GetCategorias()
        {
            var lista = _db.ListarCategorias();
            return Ok(lista);
        }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }

    public class Database
    {
        private readonly string connectionString;

        public Database(string servidor, string banco, string usuario, string senha)
        {
            connectionString = $"Server={servidor};Database={banco};User ID={usuario};Password={senha};";
        }

        public bool TestarConexao()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Categoria> ListarCategorias()
        {
            var categorias = new List<Categoria>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT id, nome, descricao FROM categorias";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = reader.GetInt32("id"),
                    Nome = reader.GetString("nome"),
                    Descricao = reader.GetString("descricao")
                });
            }

            return categorias;
        }
    }
}

