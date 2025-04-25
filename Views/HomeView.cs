using CicloStock.Utilitarios;
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
            while (true)
            {
                try
                {
                        Console.Clear();
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
                            case 5: return;
                            default: throw new Exception();
                        }
                }
                catch (Exception ex)
                {
                    Info.ExibirEspera($"| ERRO! {ex.Message}");
                }
            }
        }
    }
}
