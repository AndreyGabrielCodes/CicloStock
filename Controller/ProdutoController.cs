using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CicloStock.Models;
using CicloStock.Operacoes;
using Microsoft.Extensions.Primitives;

namespace CicloStock.Controller
{
    public class ProdutoController
    {
        private static void VerificarIdInserido(int id)
        {
            if (id == 0 || id == null)
                throw new Exception("| Id inserido inválido");

            if (!ProdutoOP.VerificarId(id))
                throw new Exception("| Produto com Id inserido não existe");
        }
        
        public static string ExibirProdutos()
        {
            List<ProdutoModel> lista = ProdutoOP.ListarProdutos();

            if (lista.Count == 0 || lista == null)
                throw new Exception("| Não há produtos cadastrados");

            lista.OrderByDescending(x => x.Situacao);

            string texto = "";
            string situacaoTexto = "";

            StringBuilder sb = new StringBuilder();

            sb.Append("| Id | Situação | Nome\n");
            sb.Append("");
            foreach (ProdutoModel produto in lista)
            {
                if (Convert.ToInt32(produto.Situacao) == 0)
                    situacaoTexto = "Inativo";
                else if (Convert.ToInt32(produto.Situacao) == 1);
                    situacaoTexto = "Ativo";
                sb.Append("| " + produto.ProdutoId + " | " + situacaoTexto + " | " + produto.Descricao + "\n");
            }

            return sb.ToString();
        }


        public static bool InserirProduto(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("| Nome inserido não é válido");

            ProdutoModel produtoNovo = new ProdutoModel();
            produtoNovo.Descricao = descricao;
            produtoNovo.Situacao = Utilitarios.Enumerados.SituacaoProduto.Ativo;

            if (!ProdutoOP.Inserir(produtoNovo))
                throw new Exception("| Não foi possível inserir o produto");

            return true;
        }

        public static bool ExcluirProduto(int id)
        {
            VerificarIdInserido(id);
            
            ProdutoModel produtoAExcluir = ProdutoOP.RetornarProduto(id);

            ProdutoOP.Excluir(produtoAExcluir);

            return true;
        }

        public static bool AlterarProduto(int id, string descricao)
        {
            VerificarIdInserido(id);

            var produto = ProdutoOP.RetornarProduto(id);

            ProdutoOP.Alterar(produto, descricao);

            return true;
        }
    }
}
