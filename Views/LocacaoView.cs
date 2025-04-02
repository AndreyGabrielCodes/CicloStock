using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class LocacaoView
    {
        public static void Menu()
        {
            Console.WriteLine("| LOCAÇÕES");
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
            Console.WriteLine("| ADICIONAR LOCACAO");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome do locação");
            var nome = Console.ReadLine();
            ProdutoView.Visualizar();
            Console.WriteLine("| Digite o ID do produto dessa locação");
            var id = int.Parse(Console.ReadLine());
            
            //Controller para criar locação
        }
        private static void Alterar()
        {
            Console.WriteLine("| ALTERAR LOCAÇÃO");
            Visualizar();
            Console.WriteLine("| Digite o ID a alterar");
            var id = int.Parse(Console.ReadLine());

            //Controller de verificação de ID

            Console.WriteLine("| Digite o novo nome da locação");
            var nome = Console.ReadLine();

            //Controller para alterar locação
        }
        private static void AlterarSituacao()
        {
            Console.WriteLine("| EXCLUIR OU INATIVAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| *Locações com produtos serão inativas");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Excluir ou Inativar locação");
            Console.WriteLine("| 2 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Console.Clear();
                Visualizar();
                Console.WriteLine("| Digite o ID do locação");
                var id = int.Parse(Console.ReadLine());
                //Controller aqui
            }
        }

    }
}
