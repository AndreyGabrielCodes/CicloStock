﻿using CicloStock.Controller;
using CicloStock.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Views
{
    public class LocacaoView
    {
        public static void Menu()
        {
            Console.WriteLine("| LOCAÇÕES");
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
            Console.WriteLine("| VISUALIZAR LOCAÇÃO");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Visualizar locações");
            Console.WriteLine("| 2 - Visualizar produtos de locações");
            Console.WriteLine("| 3 - Voltar");
            var opcao = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine(LocacaoController.ExibirLocacoes());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine(LocacaoController.ExibirLocacoes());
                    Console.WriteLine("| Digite o ID da locação a visualizar os produtos");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine(LocacaoController.ExibirProdutoLocacao(id));
                    Console.ReadKey();
                    break;
                case 3: break;
                default: throw new Exception("Opção inserida é inválida");
            }

            Console.Clear();
        }
        private static void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("| ADICIONAR LOCAÇÃO");
            Console.WriteLine("|");
            Console.WriteLine("| Digite a descrição da locação");
            var descricao = Console.ReadLine();

            LocacaoController.InserirLocacao(descricao);

            Info.ExibirEspera("| Locação inserida!");
        }
        private static void Alterar()
        {
            Console.WriteLine("| ALTERAR LOCAÇÃO");
            Console.WriteLine("|");
            Console.WriteLine("| 1 - Alterar descrição");
            Console.WriteLine("| 2 - Alterar situação");
            Console.WriteLine("| 3 - Voltar");
            var opcao = int.Parse(Console.ReadLine());

            Console.WriteLine(LocacaoController.ExibirLocacoes());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("| Digite o ID a alterar");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine("| Digite a nova descrição da locação");
                    var descricao = Console.ReadLine();
                    LocacaoController.AlterarNomeLocacao(id, descricao);
                    break;
                case 2:
                    Console.WriteLine("| Digite o ID a alterar");
                    id = int.Parse(Console.ReadLine());

                    Console.WriteLine("| *Se a situação for principal será alterada para alternativa");
                    Console.WriteLine("| *Se a situação for alternativa será alterada para principal");
                    Thread.Sleep(3000);
                    LocacaoController.AlterarSituacaoLocacao(id);
                    break;
                case 3:
                    return;
                default: throw new Exception("Opção inserida é inválida");
            }

            Info.ExibirEspera("| Locação alterada!");
        }
        private static void Excluir()
        {
            Console.WriteLine("| EXCLUIR LOCAÇÃO");
            Console.WriteLine("|");
            Console.WriteLine("| *Não pode existir produto na locação para excluir");
            Console.WriteLine("|");
            Console.WriteLine(LocacaoController.ExibirLocacoes());
            Console.WriteLine("| Digite o ID a excluir");
            var id = int.Parse(Console.ReadLine());

            LocacaoController.ExcluirProduto(id);
                
            Info.ExibirEspera("| Locação excluida!");
        }
    }
}
