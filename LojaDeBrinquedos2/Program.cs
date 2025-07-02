using MySql.Data.MySqlClient;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddSingleton(new Database("localhost", "meu_banco", "root", "Natalli17**"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class Database
{
    private readonly string connectionString;

    public Database(string servidor, string banco, string usuario, string senha)
    {
        connectionString = $"Server={servidor};Database={banco};User ID={usuario};Password={senha};";
    }

    public void TestConnection()
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        Console.WriteLine("Conexão com o banco realizada com sucesso.");
        conn.Close();
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

    internal object ListarCategorias()
    {
        throw new NotImplementedException();
    }
}