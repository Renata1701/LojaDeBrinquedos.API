using MySqlX.XDevAPI.Common;

namespace LojaDeBrinquedos2.Services;

public class ProdutoService
{

    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<Produto>>> GetAllAsync(string? nomeFiltro = null)
    {
        var produtos = await _repository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(nomeFiltro))
        {
            produtos = produtos
                .Where(p => p.Nome.Contains(nomeFiltro, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        return Result<List<Produto>>.Ok(produtos);
    }

    public async Task<Result<Produto>> GetByIdAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
            return Result<Produto>.Fail("Produto não encontrado");

        return Result<Produto>.Ok(produto);
    }

    public async Task<Result<Produto>> CreateAsync(Produto produto)
    {
        var validation = ValidarProduto(produto);
        if (!validation.Success)
            return Result<Produto>.Fail(validation.ErrorMessage!);

        await _repository.AddAsync(produto);

        return Result<Produto>.Ok(produto);
    }

    public async Task<Result<Produto>> UpdateAsync(Produto produto)
    {
        var existing = await _repository.GetByIdAsync(produto.Id);

        if (existing == null)
            return Result<Produto>.Fail("Produto não encontrado");

        var validation = ValidarProduto(produto);
        if (!validation.Success)
            return Result<Produto>.Fail(validation.ErrorMessage!);

        existing.Nome = produto.Nome;
        existing.Descricao = produto.Descricao;
        existing.Preco = produto.Preco;
        existing.Marca = produto.Marca;
        existing.Categoria = produto.Categoria;
        existing.CodigoBarras = produto.CodigoBarras;
        existing.ImagemUrl = produto.ImagemUrl;

        await _repository.UpdateAsync(existing);

        return Result<Produto>.Ok(existing);
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
            return Result<bool>.Fail("Produto não encontrado");

        await _repository.DeleteAsync(id);

        return Result<bool>.Ok(true);
    }

    // Validação interna simples
    private Result<bool> ValidarProduto(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
            return Result<bool>.Fail("Nome é obrigatório");

        if (produto.Preco < 0)
            return Result<bool>.Fail("Preço não pode ser negativo");

        // Exemplo: validar código de barras numérico e com 13 dígitos
        if (!string.IsNullOrWhiteSpace(produto.CodigoBarras) &&
            (produto.CodigoBarras.Length != 13 || !produto.CodigoBarras.All(char.IsDigit)))
        {
            return Result<bool>.Fail("Código de barras inválido");
        }

        return Result<bool>.Ok(true);
    }
}


}
