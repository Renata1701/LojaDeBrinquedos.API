namespace LojaDeBrinquedos2.Services
{
    public class ProdutoService
    {
		private static List<Produto> _produtos = new();
		private static int _proximoId = 1;

		public List<Produto> ListarTodos() => _produtos;

		public Produto BuscarPorId(int id) =>
			_produtos.FirstOrDefault(p => p.Id == id);

		public Produto Criar(Produto produto)
		{
			produto.Id = _proximoId++;
			_produtos.Add(produto);
			return produto;
		}

		public bool Remover(int id)
		{
			var p = BuscarPorId(id);
			if (p == null) return false;
			_produtos.Remove(p);
			return true;
		}
	}
}
    }
}
