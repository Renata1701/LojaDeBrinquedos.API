
namespace LojaDeBrinquedos2.Services;

public interface IProdutoRepository
{
    Task<IEnumerable<object>> GetAllAsync();
}