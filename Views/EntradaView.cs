using CicloStock.Controller;
using CicloStock.Utilitarios;

namespace CicloStock.Views
{
    public class EntradaView
    {
        public static void Menu()
        {
            Console.WriteLine("| ENTRADAS");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Visualizar");
            Console.WriteLine("| 2 - Adicionar");
            Console.WriteLine("| 3 - Cancelar");
            Console.WriteLine("| 4 - Voltar");
            var opcao = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case 1: Visualizar();break;
                case 2: Adicionar(); break;
                case 3: Cancelar(); break;
                case 4: break;
                default: throw new Exception();
            }
        }
        private static void Visualizar()
        {
            Console.WriteLine(EntradaController.ExibirEntradas());

            Info.ExibirContinuar();
        }
        private static void Adicionar() 
        {
            Console.WriteLine("| ADICIONAR ENTRADA");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome da entrada");
            var nome = Console.ReadLine();

            EntradaController.InserirEntrada(nome);

            Info.ExibirEspera("| Entrada inserida!");
        }
        private static void Cancelar()
        {
            Console.WriteLine("| CANCELAR ENTRADA");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Cancelar entrada");
            Console.WriteLine("| 2 - Voltar");
            var opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.Clear();
                Visualizar();
                Console.WriteLine("| Digite o ID a cancelar");
                var id = int.Parse(Console.ReadLine());

                EntradaController.AlterarSituacao(id, Enumerados.SituacaoEntrada.Cancelado);

                Info.ExibirEspera("| Entrada cancelada!");
            }
        }
    }
}
