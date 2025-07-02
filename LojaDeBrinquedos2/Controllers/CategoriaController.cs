using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    
        private readonly string connectionString = "Server=localhost;Database=meu_banco;User ID=root;Password=Natalli17**;";

    [HttpGet]
    public IActionResult GetCategorias()
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

        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult GetPorId(int id)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "SELECT id, nome, descricao FROM categorias WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var categoria = new Categoria
            {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Descricao = reader.GetString("descricao")
            };
            return Ok(categoria);
        }

        return NotFound("Categoria não encontrada.");
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Categoria novaCategoria)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "INSERT INTO categorias (nome, descricao) VALUES (@nome, @descricao)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nome", novaCategoria.Nome);
        cmd.Parameters.AddWithValue("@descricao", novaCategoria.Descricao);
        cmd.ExecuteNonQuery();

        return Ok("Categoria adicionada com sucesso.");
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Categoria categoria)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "UPDATE categorias SET nome = @nome, descricao = @descricao WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nome", categoria.Nome);
        cmd.Parameters.AddWithValue("@descricao", categoria.Descricao);

        int linhasAfetadas = cmd.ExecuteNonQuery();

        if (linhasAfetadas > 0)
            return Ok("Categoria atualizada com sucesso.");
        else
            return NotFound("Categoria não encontrada.");
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "DELETE FROM categorias WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        int linhasAfetadas = cmd.ExecuteNonQuery();

        if (linhasAfetadas > 0)
            return Ok("Categoria deletada com sucesso.");
        else
            return NotFound("Categoria não encontrada.");
    }
}

public class Categoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
}



