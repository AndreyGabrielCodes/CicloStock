using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CicloStock.Models;
using CicloStock.Operacoes;
using CicloStock.Utilitarios;
using Microsoft.Extensions.Primitives;

namespace CicloStock.Controller
{
    public class ProdutoController
    {
        public static void VerificarIdInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!ProdutoOP.VerificarId(id))
                throw new Exception("| Produto com Id inserido não existe");
        }
        
        public static string ExibirProdutos()
        {
            List<ProdutoModel> lista = ProdutoOP.ListarProdutos()
                .Where(x => x.Situacao != Enumerados.SituacaoProduto.Inativo)
                .OrderByDescending(x => x.Situacao)
                .ToList();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há produtos cadastrados");

            string situacaoTexto = "";

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");
            foreach (ProdutoModel produto in lista)
            {
                if (produto.Situacao == Enumerados.SituacaoProduto.Inativo)
                    situacaoTexto = "Inativo";
                else if (produto.Situacao == Enumerados.SituacaoProduto.Ativo)
                    situacaoTexto = "Ativo";
                sb.Append("| " + produto.ProdutoId + " | " + situacaoTexto + " | " + produto.Descricao + "\n");
            }

            return sb.ToString();
        }

        public static void InserirProduto(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("| Nome inserido não é válido");

            ProdutoModel produtoNovo = new ProdutoModel();
            produtoNovo.Descricao = descricao;
            produtoNovo.Situacao = Enumerados.SituacaoProduto.Ativo;

            ProdutoOP.Inserir(produtoNovo);
        }

        public static void ExcluirProduto(int id)
        {
            VerificarIdInserido(id);
            
            ProdutoModel produtoAExcluir = ProdutoOP.RetornarProduto(id);

            ProdutoOP.Excluir(produtoAExcluir);
        }

        public static void AlterarProduto(int id, string descricao)
        {
            VerificarIdInserido(id);

            var produto = ProdutoOP.RetornarProduto(id);

            ProdutoOP.Alterar(produto, descricao);
        }

        public static void AlterarLocacaoProduto(int idLocacaoAntiga, int idLocacaoNova, int idProduto)
        {
            VerificarIdInserido(idProduto);
            LocacaoController.VerificarIdInserido(idLocacaoNova);

            var produto = ProdutoOP.RetornarProduto(idProduto);
            var locacaoNova = LocacaoOP.RetornarLocacao(idLocacaoNova);
            var locacaoAntiga = LocacaoOP.RetornarLocacao(idLocacaoAntiga);

            if (locacaoAntiga != null && locacaoNova.LocacaoId == locacaoAntiga.LocacaoId)
                throw new Exception("| Id da locação a transferir é a mesma da locação atual ");

            LocacaoOP.AlterarLocacaoProduto(locacaoAntiga, locacaoNova, produto);
        }

        public static bool ProdutoPossuiLocacao(int idProduto)
        {
            ProdutoController.VerificarIdInserido(idProduto);

            var produto = ProdutoOP.RetornarProduto(idProduto);

            var locacoes = LocacaoOP.RetornarLocacaoPorProduto(produto);

            if (locacoes == null || locacoes.Count == 0)
                return false;

            return true;
        }
    }
}
