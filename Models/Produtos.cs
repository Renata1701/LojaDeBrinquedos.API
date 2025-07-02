using Microsoft.AspNetCore.Mvc;

namespace LojadeBrinquedos_api.Models
{
    public class ProdutoController
    {
        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public decimal Preco { get; set; }
            public string Marca { get; set; }
            public string CodigoBarras { get; set; }
            public string ImagemUrl { get; set; }
            public int CategoriaProdutoId { get; set; }
            public Produto(int id, string nome, string descricao, decimal preco, string marca, string codigoBarras, string imagemUrl, int categoriaProdutoId)
            {
                Id = id;
                Nome = nome;
                Descricao = descricao;
                Preco = preco;
                Marca = marca;
                CodigoBarras = codigoBarras;
                ImagemUrl = imagemUrl;
                CategoriaProdutoId = categoriaProdutoId;

            }


            public class CategoriaProduto
            {
                public int Id { get; set; }
                public string Nome { get; set; }
                public string Descricao { get; set; }
                public ICollection<Produto> Produtos { get; set; }
                public CategoriaProduto(int id, string nome, string descricao)
                {
                    Id = id;
                    Nome = nome;
                    Descricao = descricao;
                }
            }
        }




    }




}
