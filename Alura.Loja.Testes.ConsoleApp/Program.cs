using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GravarUsandoEntity();
        }

        private static void AtualizarProduto()
        {
            //inclui produto
            GravarUsandoEntity();

            //atualizar o produto
            using (var repo = new ProdutoDAOEntity())
            {
                Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Harry Potter e As Relíquias da Morte";
                repo.Atualizar(primeiro);
            }
            RecuperarProdutos();
             
        }

        private static void ExcluirProduto()
        {
            using (var repo = new ProdutoDAOEntity()) {
                IList<Produto> produtos = repo.Produtos();
                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new LojaContext()){

                IList<Produto> produtos = repo.Produtos.ToList();
                foreach (var item in produtos)
                {
                    Console.WriteLine("Possui {0} produtos: ", produtos.Count);
                    Console.WriteLine(item.Nome);
                    Console.ReadKey();
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
                
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
