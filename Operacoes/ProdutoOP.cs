using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;

namespace CicloStock.Operacoes
{
    public class ProdutoOP
    {
        public static ProdutoModel RetornarProduto(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var produto = context.ProdutoCXT.Where(x=> Convert.ToInt32(x.ProdutoId) == id).FirstOrDefault();
                    return produto;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar registros");
                }
            }
        }
        
        public static List<ProdutoModel> ListarProdutos()
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
                    var produto = context.ProdutoCXT.Where(x => x.ProdutoId == id && x.Situacao == Enumerados.SituacaoProduto.Ativo).FirstOrDefault();
                    if (produto == null)
                        return false;

                    return true;
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

        public static void Alterar(ProdutoModel produto, string descricao)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    produto.Descricao = descricao;
                    context.ProdutoCXT.Update(produto);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar");
            }
        }

        public static void Excluir(ProdutoModel produto)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    var produtoEmLote = context.EntradaLoteItemCXT.Where(x => x.Produto == produto).FirstOrDefault();
                    
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
