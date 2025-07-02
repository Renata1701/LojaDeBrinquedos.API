using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos2.Controllers;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly string connectionString = "Server=localhost;Database=meu_banco;User ID=root;Password=Natalli17**;";

 
    [HttpGet("listar")]
    public IActionResult Listar()
    {
        var produtos = new List<Produto>();
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var cmd = new MySqlCommand("SELECT * FROM produtos", conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(new Produto
            {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Descricao = reader.GetString("descricao"),
                Preco = reader.GetDecimal("preco"),
                CategoriaId = reader.GetInt32("categoria_id"),
                FornecedorId = reader.GetInt32("fornecedor_id"),
                Estoque = reader.GetInt32("estoque")
            });
        }

        return Ok(produtos);
    }

  
    [HttpPost("adicionar")]
    public IActionResult Adicionar(Produto produto)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var cmd = new MySqlCommand(@"INSERT INTO produtos 
                (nome, descricao, preco, categoria_id, fornecedor_id, estoque) 
                VALUES (@nome, @descricao, @preco, @categoria, @fornecedor, @estoque)", conn);

        cmd.Parameters.AddWithValue("@nome", produto.Nome);
        cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
        cmd.Parameters.AddWithValue("@preco", produto.Preco);
        cmd.Parameters.AddWithValue("@categoria", produto.CategoriaId);
        cmd.Parameters.AddWithValue("@fornecedor", produto.FornecedorId);
        cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

        cmd.ExecuteNonQuery();
        return Ok("Produto adicionado com sucesso!");
    }

   
    [HttpPut("editar/{id}")]
    public IActionResult Editar(int id, Produto produto)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var cmd = new MySqlCommand(@"UPDATE produtos SET 
                nome=@nome, descricao=@descricao, preco=@preco, 
                categoria_id=@categoria, fornecedor_id=@fornecedor, estoque=@estoque 
                WHERE id=@id", conn);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nome", produto.Nome);
        cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
        cmd.Parameters.AddWithValue("@preco", produto.Preco);
        cmd.Parameters.AddWithValue("@categoria", produto.CategoriaId);
        cmd.Parameters.AddWithValue("@fornecedor", produto.FornecedorId);
        cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

        int linhas = cmd.ExecuteNonQuery();
        if (linhas > 0)
            return Ok("Produto atualizado com sucesso!");
        else
            return NotFound("Produto não encontrado.");
    }

  
    [HttpDelete("deletar/{id}")]
    public IActionResult Deletar(int id)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var cmd = new MySqlCommand("DELETE FROM produtos WHERE id=@id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        int linhas = cmd.ExecuteNonQuery();

        if (linhas > 0)
            return Ok("Produto removido com sucesso!");
        else
            return NotFound("Produto não encontrado.");
    }
}

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public int FornecedorId { get; set; }
    public int Estoque { get; set; }
}




