using CicloStock.Models;
using CicloStock.Operacoes;
using CicloStock.Utilitarios;
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
                if (entrada.Situacao == Enumerados.SituacaoEntrada.Aberto)
                    situacaoTexto = "Aberto";
                else if (entrada.Situacao == Enumerados.SituacaoEntrada.EmAndamento)
                    situacaoTexto = "Em Andamento";
                else if (entrada.Situacao == Enumerados.SituacaoEntrada.Concluido)
                    situacaoTexto = "Concluido";
                else if (entrada.Situacao == Enumerados.SituacaoEntrada.Cancelado)
                    situacaoTexto = "Cancelado";
                sb.Append("| " + entrada.EntradaId + " | " + situacaoTexto + " | " + entrada.Descricao + "\n");
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
                throw new Exception("| Não há entradas cadastradas");

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");

            foreach (EntradaLoteModel entrada in lista)
            {
                sb.Append("| " + entrada.EntradaId + " | " + entrada.Descricao + "\n");
            }

            return sb.ToString();
        }

        public static void VerificarIdLoteInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!EntradaOP.VerificarIdLote(id))
                throw new Exception("| Produto com Id inserido não existe");
        }

        public static void InserirLote(int idEntrada)
        {

        }

        public static void InserirProdutoLote()
        {

        }

        #endregion
    }
}
