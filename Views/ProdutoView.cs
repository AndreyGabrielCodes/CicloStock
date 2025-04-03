using CicloStock.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class ProdutoView
    {
        public static void Menu()
        {
            Console.WriteLine("| PRODUTOS");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Visualizar");
            Console.WriteLine("| 2 - Adicionar");
            Console.WriteLine("| 3 - Alterar");
            Console.WriteLine("| 4 - Excluir");
            Console.WriteLine("| 5 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            
            switch (opcao)
            {
                case 1: Visualizar(); break;
                case 2: Adicionar(); break;
                case 3: Alterar(); break;
                case 4: Excluir(); break;
                case 5: break;
                default: throw new Exception("Opção inserida é inválida");
            }
            Console.Clear();
        }
        public static void Visualizar()
        {
            Console.Clear();

            var lista = ProdutoController.ExibirProdutos();

            Console.WriteLine(lista);

            Console.ReadKey();
        }
        private static void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("| ADICIONAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome do produto");
            var nome = Console.ReadLine();

            Console.Clear();

            if (ProdutoController.InserirProduto(nome));
                Console.WriteLine("| Produto inserido!");

            Console.ReadKey();
        }
        private static void Alterar()
        {
            Console.WriteLine("| ALTERAR PRODUTO");
            Visualizar();
            Console.WriteLine("| Digite o ID a alterar");
            var id = int.Parse(Console.ReadLine());

            if (ProdutoController.VerificarIdInserido(id))
            {
                Console.WriteLine("| Digite o novo nome do produto");
                var nome = Console.ReadLine();
            }
        }
        private static void Excluir()
        {
            Console.WriteLine("| EXCLUIR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| *Produtos contidos em lotes serão inativos");
            Console.WriteLine("|");
            Visualizar();
            Console.WriteLine("| Digite o ID a alterar");
            var id = int.Parse(Console.ReadLine());

            ProdutoController.ExcluirProduto(id);
            
        }
    }
}
