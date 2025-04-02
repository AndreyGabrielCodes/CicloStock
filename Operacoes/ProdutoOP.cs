using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;

namespace CicloStock.Operacoes
{
    public class ProdutoOP
    {
        public static List<ProdutoModel> Visualizar()
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.ProdutoCXT.ToList();
                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros");
                }
            }
        }

        public static bool VerificarId(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    //Não é permitido alterar um produto inativo
                    var lista = context.ProdutoCXT.Where(x => x.ProdutoId == id && x.Situacao == Enumerados.SituacaoProduto.Ativo);
                    if (lista != null)
                        return true;
                    return false;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar o Id");
                }
            }
        }
        
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
    }
}
