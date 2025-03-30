using CicloStock.Mapping;
using CicloStock.Models;

namespace CicloStock.Operacoes
{
    public class ProdutoOP
    {
        #region Produto
        public static void Inserir(ProdutoModel produto)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    context.ProdutoCXT.Add(produto);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível inserir o registro");
                }
            }
        }

        public static void Alterar(ProdutoModel produto, ProdutoModel produtoNovo)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    produto.Descricao = produtoNovo.Descricao;
                    produto.Situacao = produtoNovo.Situacao;
                    produto.Locacoes = produtoNovo.Locacoes;
                    produto.CodigoBarras = produtoNovo.CodigoBarras;
                    context.ProdutoCXT.Update(produto);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar");
            }
        }

        public static void Remover(ProdutoModel produto)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    context.ProdutoCXT.Remove(produto);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível remover");
            }
        }
        #endregion
    }
}
