using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class EntradaView
    {

        public static void Menu()
        {
            Console.WriteLine("| ENTRADAS");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Visualizar");
            Console.WriteLine("| 2 - Continuar");
            Console.WriteLine("| 3 - Adicionar");
            Console.WriteLine("| 4 - Cancelar");
            Console.WriteLine("| 5 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); Console.ReadKey();break;
                case 2: Continuar(); break;
                case 3: Adicionar(); break;
                case 4: Cancelar(); break;
                case 5: break;
                default: throw new Exception();
            }
        }
        
        private static void Visualizar()
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
        }

        private static void Adicionar() 
        {
            Console.WriteLine("| ADICIONAR ENTRADA");
            Console.WriteLine("|");
            var opcao = int.Parse(Console.ReadLine());
        }
        private static void Cancelar()
        {
            Console.WriteLine("| CANCELAR ENTRADA");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Cancelar entrada?");
            Console.WriteLine("| 2 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                //Controller aqui
            }
        }
    }
}
