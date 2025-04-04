using CicloStock.Models;
using CicloStock.Operacoes;
using CicloStock.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Controller
{
    public class LocacaoController
    {
        private static void VerificarIdInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!LocacaoOP.VerificarId(id))
                throw new Exception("| Locação com Id inserido não existe");
        }
        public static string ExibirProdutoLocacao(int id)
        {
            VerificarIdInserido(id);

            LocacaoModel locacao = LocacaoOP.RetornarLocacao(id);

            var lista = LocacaoOP.ListarProdutosLocacao(locacao);

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id Locação | Descrição Locação | Id Produto | Nome Produto\n");
            sb.Append("");

            foreach (LocacaoProdutoModel item in lista)
            {
                sb.Append("| " + item.Locacao.LocacaoId + " | " + item.Locacao.Descricao + " | " + item.Produto.ProdutoId + " | " + item.Produto.Descricao + "\n");
            }

            return sb.ToString();
        }
        public static string ExibirLocacoes()
        {
            List<LocacaoModel> lista = LocacaoOP.ListarLocacoes();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há locações cadastradas");

            lista.OrderBy(x => x.Situacao);

            string situacaoTexto = "";

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");
            foreach (LocacaoModel locacao in lista)
            {
                if (locacao.Situacao == Enumerados.SituacaoLocacao.Inativo)
                    situacaoTexto = "Inativo";
                else if (locacao.Situacao == Enumerados.SituacaoLocacao.Principal)
                    situacaoTexto = "Principal";
                else if (locacao.Situacao == Enumerados.SituacaoLocacao.Alternativo)
                    situacaoTexto = "Alternativo";
                sb.Append("| " + locacao.LocacaoId + " | " + situacaoTexto + " | " + locacao.Descricao + "\n");
            }

            return sb.ToString();
        }


        public static void InserirLocacao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("| Descrição inserida não é válida");

            LocacaoModel locacaoNova = new LocacaoModel();
            locacaoNova.Descricao = descricao;
            locacaoNova.Situacao = Enumerados.SituacaoLocacao.Principal;

            LocacaoOP.Inserir(locacaoNova);
        }

        public static void ExcluirProduto(int id)
        {
            VerificarIdInserido(id);

            LocacaoModel locacaoAExcluir = LocacaoOP.RetornarLocacao(id);

            LocacaoOP.Excluir(locacaoAExcluir);
        }

        public static void AlterarNomeLocacao(int id, string descricao)
        {
            VerificarIdInserido(id);

            var locacao = LocacaoOP.RetornarLocacao(id);

            LocacaoOP.AlterarDescricao(locacao, descricao);
        }

        public static void AlterarSituacaoLocacao(int id)
        {
            VerificarIdInserido(id);

            var locacao = LocacaoOP.RetornarLocacao(id);

            LocacaoOP.AlterarSituacao(locacao);
        }
    }
}
