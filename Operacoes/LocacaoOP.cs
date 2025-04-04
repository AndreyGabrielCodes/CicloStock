using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;
using System.ComponentModel.Design;
using System.Globalization;

namespace CicloStock.Operacoes
{
    public class LocacaoOP
    {
        public static LocacaoModel RetornarLocacao(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var locacao = context.LocacaoCXT.Where(x => Convert.ToInt32(x.LocacaoId) == id).FirstOrDefault();
                    return locacao;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar registros");
                }
            }
        }

        public static List<LocacaoModel> ListarLocacoes() 
        { 
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.LocacaoCXT.Where(x => x.Situacao != Enumerados.SituacaoLocacao.Inativo).ToList();
                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros");
                }
            }
        }

        public static List<LocacaoModel> ListarProdutosLocacao(LocacaoModel locacao)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    /*var lista = context.LocacaoCXT.Join(context.ProdutoCXT, 
                            produto => produto.Produto.ProdutoId,
                            locacao => locacao.ProdutoId,
                            (locacao, produto) => { ProdutoModel = produto, });*/
                    

                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros de produtos");
                }
            }
        }

        public static void Inserir(LocacaoModel locacao)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    context.LocacaoCXT.Add(locacao);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível inserir o registro");
                }
            }
        }

        public static void AlterarDescricao(LocacaoModel locacao, string descricao)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    locacao.Descricao = descricao;
                    context.LocacaoCXT.Update(locacao);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar");
            }
        }
        public static void AlterarSituacao(LocacaoModel locacao)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    if (locacao.Situacao == Enumerados.SituacaoLocacao.Principal)
                        locacao.Situacao = Enumerados.SituacaoLocacao.Alternativo;
                    else
                        locacao.Situacao = Enumerados.SituacaoLocacao.Principal;

                    context.LocacaoCXT.Update(locacao);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar a situação");
            }
        }

        public static void Excluir(LocacaoModel locacao)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    var produtosLocacao = context.LocacaoCXT.Where(x => x.LocacaoId == locacao.LocacaoId).Select(x => x.Produto).ToList();
                    
                    if (produtosLocacao != null || produtosLocacao.Count > 0)
                        throw new Exception();

                    context.LocacaoCXT.Remove(locacao);
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
