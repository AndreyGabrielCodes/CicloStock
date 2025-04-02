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
            Console.WriteLine("| 4 - Excluir ou Inativar");
            Console.WriteLine("| 5 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); Console.ReadKey(); break;
                case 2: Adicionar(); break;
                case 3: Alterar(); break;
                case 4: AlterarSituacao(); break;
                case 5: break;
                default: throw new Exception();
            }
        }
        public static void Visualizar()
        {
            //Controller de listagem aqui
        }
        private static void Adicionar()
        {
            Console.WriteLine("| ADICIONAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome do produto");
            var nome = Console.ReadLine();

            //Controller para criar produto
        }
        private static void Alterar()
        {
            Console.WriteLine("| ALTERAR PRODUTO");
            Visualizar();
            Console.WriteLine("| Digite o ID a alterar");
            var id = int.Parse(Console.ReadLine());

            //Controller de verificação de ID

            Console.WriteLine("| Digite o novo nome do produto");
            var nome = Console.ReadLine();

            //Controller para alterar produto
        }
        private static void AlterarSituacao()
        {
            Console.WriteLine("| EXCLUIR OU INATIVAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| *Produtos contidos em lotes serão inativos");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Excluir ou Inativar produto");
            Console.WriteLine("| 2 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Console.Clear();
                Visualizar();
                Console.WriteLine("| Digite o ID do produto");
                var id = int.Parse(Console.ReadLine());
                //Controller aqui
            }
        }
    }
}
