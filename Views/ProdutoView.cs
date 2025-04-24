using CicloStock.Controller;
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
            Console.WriteLine("| 4 - Excluir");
            Console.WriteLine("| 5 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); break;
                case 2: Adicionar(); break;
                case 3: Alterar(); break;
                case 4: Excluir(); break;
                case 5: break;
                default: throw new Exception("Opção inserida é inválida");
            }
            Console.Clear();
        }
        public static void Visualizar()
        {
            Console.WriteLine(ProdutoController.ExibirProdutos());

            Console.ReadKey();
        }
        private static void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("| ADICIONAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| Digite o nome do produto");
            var nome = Console.ReadLine();

            Console.Clear();

            ProdutoController.InserirProduto(nome);

            Console.WriteLine("| Produto inserido!");

            Thread.Sleep(3000);
        }
        private static void Alterar()
        {
            Console.WriteLine("| ALTERAR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Alterar nome");
            Console.WriteLine("| 2 - Alterar locação");
            Console.WriteLine("| 3 - Voltar");
            var opcao = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine(ProdutoController.ExibirProdutos());
                    Console.WriteLine("| Digite o ID a alterar");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine("| Digite o novo nome do produto");
                    var nome = Console.ReadLine();

                    ProdutoController.AlterarProduto(id, nome);
                    break;
                case 2:
                    Console.WriteLine("| ALTERAÇÃO DE LOCAÇÃO DE PRODUTO");
                    Console.WriteLine("|");
                    
                    Console.WriteLine(ProdutoController.ExibirProdutos());
                    Console.WriteLine("| Digite o ID do produto a transferir");
                    var idProduto = int.Parse(Console.ReadLine());

                    Console.WriteLine("| Locações atuais do produto");
                    Console.WriteLine(LocacaoController.ExibirLocacaoProduto(idProduto));

                    bool locacaoExistente = ProdutoController.ProdutoPossuiLocacao(idProduto);

                    int idLocacaoAntiga = 0;

                    if (locacaoExistente)
                    {
                        Console.WriteLine("\n| Digite o ID da locação atual do produto a retirar");
                        idLocacaoAntiga = int.Parse(Console.ReadLine());
                    }
                    
                    Console.WriteLine("\n| Locações disponíveis");
                    Console.WriteLine(LocacaoController.ExibirLocacoesSemProduto());
                    Console.WriteLine("| *É permitido transferir apenas para locações sem produtos\n");

                    Console.WriteLine("| Digite o ID da locação");
                    var idLocacaoNova = int.Parse(Console.ReadLine());

                    ProdutoController.AlterarLocacaoProduto(idLocacaoAntiga, idLocacaoNova, idProduto);

                    break;
                case 3: break;
                default: throw new Exception("Opção inserida é inválida");
            }

            if (opcao != 3)
            {
                Console.Clear();
                Console.WriteLine("| Produto alterado!");
                Thread.Sleep(3000);
            }
                
        }
        private static void Excluir()
        {
            Console.WriteLine("| EXCLUIR PRODUTO");
            Console.WriteLine("|");
            Console.WriteLine("| *Produtos contidos em lotes serão inativos");
            Console.WriteLine("|");
            Console.WriteLine(ProdutoController.ExibirProdutos());
            Console.WriteLine("| Digite o ID a excluir");
            var id = int.Parse(Console.ReadLine());

            Console.Clear();

            ProdutoController.ExcluirProduto(id);

            Console.WriteLine("| Produto excluido!");

            Thread.Sleep(3000);
        }
    }
}
