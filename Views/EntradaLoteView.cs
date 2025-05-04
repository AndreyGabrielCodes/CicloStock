using CicloStock.Controller;
using CicloStock.Utilitarios;

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
            Console.WriteLine("| 3 - Inserir Produtos");
            Console.WriteLine("| 4 - Cancelar");
            Console.WriteLine("| 5 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: Visualizar(); break;
                case 2: Adicionar(); break;
                case 3: InserirProdutosLote(); break;
                case 4: Cancelar(); break;
                case 5: break;
                default: throw new Exception();
            }
        }
        private static void Visualizar()
        {
            Console.WriteLine("| VISUALIZAR ");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Lotes");
            Console.WriteLine("| 2 - Itens de lotes");
            Console.WriteLine("| 3 - Voltar");
            var opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1: VisualizarLotes(); break;
                case 2: VisualizarLotesItens(); break;
                case 3: break;
                default: throw new Exception();
            }
        }

        private static void VisualizarLotes()
        {
            Console.WriteLine(EntradaController.ExibirEntradasPorSituacao(Enumerados.SituacaoEntrada.Aberto));

            Console.WriteLine("| Digite o ID da entrada");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine(EntradaController.ExibirLotesEntrada(idEntrada));

            Info.ExibirContinuar();
        }

        private static void VisualizarLotesItens()
        {
            Console.WriteLine(EntradaController.ExibirEntradasPorSituacao(Enumerados.SituacaoEntrada.Aberto));

            Console.WriteLine("| Digite o ID da entrada");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine(EntradaController.ExibirLotesEntrada(idEntrada));

            Console.WriteLine("| Digite o ID do lote:");
            var idEntradaLote = int.Parse(Console.ReadLine());

            Console.WriteLine(EntradaController.ExibirLotesItensEntrada(idEntradaLote));

            Info.ExibirContinuar();
        }


        private static void Adicionar()
        {
            Console.WriteLine(EntradaController.ExibirEntradasPorSituacao(Enumerados.SituacaoEntrada.Aberto));

            Console.WriteLine("| Digite o ID da entrada para adicionar lote:");
            var idEntrada = int.Parse(Console.ReadLine());

            EntradaController.VerificarIdInserido(idEntrada);

            Console.WriteLine("\n| Digite o nome para o lote:");
            var nome = Console.ReadLine();

            EntradaController.InserirLote(idEntrada, nome);

            Info.ExibirEspera($"| Lote criado com sucesso para a entrada {idEntrada}!");
        }

        private static void InserirProdutosLote()
        {
            Console.WriteLine(EntradaController.ExibirEntradasPorSituacao(Enumerados.SituacaoEntrada.Aberto));

            Console.WriteLine("| Digite o ID da entrada:");
            var idEntrada = int.Parse(Console.ReadLine());

            EntradaController.VerificarIdInserido(idEntrada);

            Console.WriteLine(EntradaController.ExibirLotesEntrada(idEntrada));

            Console.WriteLine("| Digite o ID do lote da entrada:");
            var idEntradaLote = int.Parse(Console.ReadLine());

            EntradaController.VerificarIdLoteInserido(idEntradaLote);

            var adicionarProduto = true;
            while (adicionarProduto)
            {
                try
                {
                    Console.Clear();
                    
                    Console.WriteLine(ProdutoController.ExibirProdutos());

                    Console.WriteLine("| Digite o ID do produto:");
                    var idProduto = int.Parse(Console.ReadLine());

                    Console.WriteLine("| Digite a quantidade do produto:");
                    var quantidadeProduto = int.Parse(Console.ReadLine());

                    EntradaController.InserirProdutoLote(idEntradaLote, idProduto, quantidadeProduto);

                    Console.Clear();

                    Console.WriteLine("| 1 - Adicionar mais produtos");
                    Console.WriteLine("| 2 - Finalizar");
                    var opcao = int.Parse(Console.ReadLine());

                    if (opcao == 2)
                        adicionarProduto = false;
                    else if (opcao != 1)
                        throw new Exception();
                }
                catch
                {
                    Info.ExibirEspera($"| Opção ou valor inserido é inválido! Tente Novamente");
                }
            }

            Info.ExibirEspera($"| Produtos inseridos com sucesso na entrada {idEntrada}!");
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

            Info.ExibirEspera("| Entrada cancelada!");
        }        
    }
}
