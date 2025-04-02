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
            Console.WriteLine("| 2 - Adicionar");
            Console.WriteLine("| 3 - Cancelar");
            Console.WriteLine("| 4 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); Console.ReadKey();break;
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
            var adicionarProduto = true;

            var listaProdutos = new List<int>();
            var nomeEntrada = "";

            Console.WriteLine("| ADICIONAR ENTRADA");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome da entrada");
            nomeEntrada = Console.ReadLine();
            //View dos produtos aqui
            
            while (adicionarProduto)
            {
                try
                {
                    ProdutoView.Visualizar();
                    
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
                //Controller aqui
            }
        }
    }
}
