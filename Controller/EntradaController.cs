using CicloStock.Models;
using CicloStock.Operacoes;
using CicloStock.Utilitarios;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace CicloStock.Controller
{
    public class EntradaController
    {
        #region Entrada
        public static string ExibirEntradas()
        {
            var lista = EntradaOP.ListarEntradas()
                .Where(x => x.Situacao != Enumerados.SituacaoEntrada.Cancelado)
                .OrderByDescending(x => x.EntradaId)
                .ToList();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há entradas cadastradas");

            string situacaoTexto = "";

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");

            foreach (EntradaModel entrada in lista)
            {
                sb.Append("| " + entrada.EntradaId + " | " + entrada.Situacao + " | " + entrada.Descricao + "\n");
            }

            return sb.ToString();
        }

        public static string ExibirEntradasPorSituacao(Enumerados.SituacaoEntrada situacao)
        {
            var lista = EntradaOP.ListarEntradas()
                .Where(x => x.Situacao != Enumerados.SituacaoEntrada.Cancelado)
                .OrderByDescending(x => x.EntradaId)
                .ToList();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há entradas cadastradas");

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");

            foreach (EntradaModel entrada in lista)
            {
                sb.Append("| " + entrada.EntradaId + " | " + entrada.Descricao + "\n");
            }

            return sb.ToString();
        }

        public static void InserirEntrada(string? descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("| Nome inserido não é válido");

            EntradaModel entrada = new EntradaModel();
            entrada.Descricao = descricao;
            entrada.Situacao = Enumerados.SituacaoEntrada.Aberto;

            EntradaOP.Inserir(entrada);
        }

        public static void VerificarIdInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!EntradaOP.VerificarId(id))
                throw new Exception("| Produto com Id inserido não existe");
        }

        public static void AlterarSituacao(int idEntrada, Enumerados.SituacaoEntrada situacaoNova)
        {
            VerificarIdInserido(idEntrada);

            var entrada = EntradaOP.RetornarEntrada(idEntrada);

            EntradaOP.AlterarSituacao(entrada, situacaoNova);
        }

        #endregion

        #region Lotes

        public static string ExibirLotesEntrada(int idEntrada)
        {
            var lista = EntradaOP.ListarLotes()
                .Where(x => x.EntradaId == idEntrada && x.Situacao != Enumerados.SituacaoEntradaLote.Cancelado)
                .OrderByDescending(x => x.EntradaId)
                .ToList();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há lotes cadastrados");

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome | Id Entrada\n");
            sb.Append("");

            foreach (EntradaLoteModel entrada in lista)
            {
                sb.Append("| " + entrada.EntradaLoteId + " | " + entrada.Situacao + " | " + entrada.Descricao + " | " + entrada.EntradaId + "\n");
            }

            return sb.ToString();
        }

        public static string ExibirLotesItensEntrada(int idEntradaLote)
        {
            var lista = EntradaOP.ListarLotesItens()
                .Where(x => x.EntradaLoteId == idEntradaLote)
                .OrderByDescending(x => x.EntradaLoteId)
                .ToList();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há lotes com itens cadastrados");

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Produto | Quantidade | Id EntradaLote\n");
            sb.Append("");

            foreach (EntradaLoteItemModel entrada in lista)
            {
                sb.Append("| " + entrada.EntradaLoteId + " | " + entrada.ProdutoId + " | " + entrada.Quantidade + " | " + entrada.EntradaLoteId + "\n");
            }

            return sb.ToString();
        }

        public static void VerificarIdLoteInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!EntradaOP.VerificarIdLote(id))
                throw new Exception("| EntradaLote com Id inserido não existe");
        }

        public static void InserirLote(int idEntrada, string descricao)
        {
            var entrada = EntradaOP.RetornarEntrada(idEntrada);

            var entradaLote = new EntradaLoteModel();
            entradaLote.Descricao = descricao;
            entradaLote.Situacao = Enumerados.SituacaoEntradaLote.Aberto;

            EntradaOP.InserirLote(entradaLote, entrada);
        }

        public static void InserirProdutoLote(int idEntradaLote, int idProduto, int quantidadeProduto)
        {
            ProdutoController.VerificarIdInserido(idProduto);
            VerificarIdLoteInserido(idEntradaLote);

            var produto = ProdutoOP.RetornarProduto(idProduto);
            var entradaLote = EntradaOP.RetornarEntradaLote(idEntradaLote);

            AlterarSituacao(entradaLote.EntradaId, Enumerados.SituacaoEntrada.EmAndamento);
            AlterarSituacaoLote(entradaLote.EntradaLoteId, Enumerados.SituacaoEntradaLote.EmAndamento);

            var entradaNova = new EntradaLoteItemModel();
            entradaNova.Quantidade = quantidadeProduto;

            EntradaOP.InserirItemLote(entradaNova, entradaLote, produto);
        }

        public static void AlterarSituacaoLote(int idEntradaLote, Enumerados.SituacaoEntradaLote situacaoNova)
        {
            VerificarIdLoteInserido(idEntradaLote);

            var entrada = EntradaOP.RetornarEntradaLote(idEntradaLote);

            EntradaOP.AlterarSituacaoLote(entrada, situacaoNova);
        }

        public static void CancelarLote(int idEntradaLote)
        {
            VerificarIdLoteInserido(idEntradaLote);
            var entradaLote = EntradaOP.RetornarEntradaLote(idEntradaLote);

            EntradaOP.ExcluirItensLote(entradaLote);

            EntradaOP.AlterarSituacaoLote(entradaLote, Enumerados.SituacaoEntradaLote.Cancelado);
        }

        #endregion
    }
}
