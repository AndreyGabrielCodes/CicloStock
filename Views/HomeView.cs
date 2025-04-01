using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class HomeView
    {
        public static void Menu()
        {
            try
            {
                Console.WriteLine("| CicloStock");
                Console.WriteLine("|");
                Console.WriteLine("| 1 - Entradas");
                Console.WriteLine("| 2 - Lotes");
                Console.WriteLine("| 3 - Produtos");
                Console.WriteLine("| 4 - Locações");
                Console.WriteLine("| 5 - Sair");
                var opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1: EntradaView.Menu(); break;
                    case 2: EntradaLoteView.Menu(); break;
                    case 3: ProdutoView.Menu(); break;
                    case 4: LocacaoView.Menu(); break;
                    //cRIAR O 5 AQUI
                    default: throw new Exception();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Opção ou valor inserido é inválido");
                Console.ReadKey();
            }
        }

    }
}
