using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LojaDeBrinquedos2.Db_Context;
[Route("api/[testarConexão]")]
[ApiController]



public class TesteController(TesteController.Database db) : ControllerBase


{
    private readonly Programa.Database _db = db;
    private string? connectionString;
    private object? v1;
    private object? v2;
    private object? v3;
    private object? v4;

    [HttpGet("conexao")]
    public IActionResult VerificarConexao()
    {
        try
        {
            _db.TestConnection();
            return Ok("Conexão com o banco de dados feita com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro na conexão: " + ex.Message);
        }
    }

    public class Database
    {
    }
internal void TestConnection()
    {
        connectionString = $"Server={v1};Database={v2};User ID={v3};Password={v4};";
        using var conn = new MySqlConnection(connectionString);
        conn.Open();  
        conn.Close();
    }
}

public class Database
{
    private readonly string _connectionString;
    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }
    public void TestConnection()
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        conn.Close();
    }
}
   

