using MySql.Data.MySqlClient;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


IServiceCollection serviceCollection = builder.Services.AddSingleton(implementationInstance: new DataBase("localhost", "meu_banco", "root", "Natalli17**"));
builder.Configuration.GetConnectionString("DefaultConnection");

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

class DataBase
{
    private string _connectionString;
    private string v;

    public DataBase(string server, string database, string user, string password)
    {
        _connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
    }

    public DataBase(string server, string database, string user, string password, string v) : this(server, database, user, password)
    {
        this.v = v;
    }

    public DataBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool TestarConexao()
    {
        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
    public void TestConnection()
    {
        if (TestarConexao())
        {
            Console.WriteLine("Conexão bem-sucedida!");
        }
        else
        {
            Console.WriteLine("Falha na conexão.");
        }
    }
    public List<string> ListarCategorias()
    {
        var categorias = new List<string>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT nome FROM categorias", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    categorias.Add(reader.GetString(0));
                }
            }
        }
        return categorias;
    }
    public bool InserirCategoria(string nome)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("INSERT INTO categorias (nome) VALUES (@nome)", connection);
            command.Parameters.AddWithValue("@nome", nome);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
