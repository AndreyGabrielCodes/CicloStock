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
            Console.WriteLine("| LOTES ");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Visualizar");
            Console.WriteLine("| 2 - Adicionar");
            Console.WriteLine("| 3 - Cancelar");
            Console.WriteLine("| 4 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); Console.ReadKey(); break;
                case 2: Adicionar(); break;
                case 3: Cancelar(); break;
                case 4: break;
                default: throw new Exception();
            }
        }
        private static void Visualizar()
        {
            //Controller de listagem aqui
        }
        private static void Adicionar()
        {
            //Controller de entradas em andamento aqui

            Console.WriteLine("| Digite o ID da entrada:");
            var idEntrada = int.Parse(Console.ReadLine());
            Console.Clear();

            //Controller com a quantidade de itens do lote
            
            var listaProdutos = new List<int>();
            var adicionarProduto = true;
            while (adicionarProduto) // alterar aqui para quantidade dos itens do lote
            {
                try
                {
                    //Controller de exibição dos itens da entrada que não estão em lotes

                    Console.WriteLine("| Digite o ID do produto:");
                    var idProduto = int.Parse(Console.ReadLine());
                    Console.WriteLine("| Digite a quantidade do produto:");
                    var quantidadeProduto = int.Parse(Console.ReadLine());

                    //Controller para adicionar o produto ao lote

                    Console.WriteLine("| 1 - Adicionar produto (ID)");
                    Console.WriteLine("| 2 - Finalizar");
                    var opcao = int.Parse(Console.ReadLine());

                    //Controller de verificação de produto válido

                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            listaProdutos.Add(opcao);
                            break;
                        case 2:
                            adicionarProduto = false;
                            break;
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

            //Controller para adicionar item a entrada
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
                Console.Clear();
                Visualizar();
                Console.WriteLine("| Digite o ID a cancelar");
                var id = int.Parse(Console.ReadLine());
                //Controller aqui
            }
        }        
    }
}
