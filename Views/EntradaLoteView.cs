using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class EntradaLoteView
    {
        public static void Menu()
        {
        }
        public static void VisualizarLotes()
        {
            //Controller de listagem aqui
        }

        private static void Continuar()
        {
            Console.WriteLine("| CONTINUAR ENTRADA");

            //controller de exibição de entradas em andamento

            Console.WriteLine("| Digite um ID:");
            var opcao = int.Parse(Console.ReadLine());

            //Controller de verificação aqui

            EntradaLoteView.VisualizarLotes();
        }

        public static void AdicionarLote()
        {

        }

        private static void Cancelar()
        {
            Console.WriteLine("| CANCELAR LOTE");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Cancelar lote");
            Console.WriteLine("| 2 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                //Controller aqui
            }
        }
    }
}
