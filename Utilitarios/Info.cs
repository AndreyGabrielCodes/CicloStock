namespace CicloStock.Utilitarios
{
    public class Info
    {
        private const int _tempoTotalSegundos = 4;
        private const string _mensagemContinuar = "ENTER para continuar...";

        public static void ExibirEspera(string texto)
        {
            for (int i = _tempoTotalSegundos; i > 0; i--)
            {
                Console.Clear();

                Console.WriteLine(texto);

                string pluralSegundos = "segundos";
                if (i == 1)
                    pluralSegundos = "segundo";

                Console.WriteLine($"| Retornando ao menu principal em {i} {pluralSegundos}...");

                Thread.Sleep(1000);
            }
        }

        public static void ExibirContinuar()
        {
            Console.WriteLine(_mensagemContinuar);
            Console.ReadKey();
        }
    }
}
