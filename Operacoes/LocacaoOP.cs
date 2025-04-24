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

        public static List<LocacaoModel>? RetornarLocacaoPorProduto(ProdutoModel produto)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var locacao = context.LocacaoCXT.Where(x => x.Produto == produto).ToList();
                    return locacao;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar registros");
                }
            }
        }

        public static bool VerificarId(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var produto = context.LocacaoCXT.Where(x => x.LocacaoId == id && x.Situacao != Enumerados.SituacaoLocacao.Inativo).FirstOrDefault();
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

        public static List<LocacaoModel> ListarLocacoesSemProduto()
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.LocacaoCXT
                        .Where(x => x.Situacao != Enumerados.SituacaoLocacao.Inativo && x.Produto == null)
                        .ToList();
                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros");
                }
            }
        }

        public static List<LocacaoProdutoModel> RetornarProdutoDeLocacao(LocacaoModel locacaoSelecionada)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.LocacaoCXT
                        .Join(context.ProdutoCXT,
                            locacao => locacao.Produto.ProdutoId,
                            produto => produto.ProdutoId,
                            (locacao, produto) => new { locacao, produto })
                        .Where(x => x.locacao.LocacaoId == locacaoSelecionada.LocacaoId && x.produto.Situacao != Enumerados.SituacaoProduto.Inativo)
                        .OrderBy(x=> x.locacao.LocacaoId)
                        .Select(x=> new LocacaoProdutoModel()
                            { 
                                Produto = x.produto,
                                Locacao = x.locacao
                            })
                        .ToList();
                    
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

        public static void AlterarLocacaoProduto(LocacaoModel? locacaoAntiga, LocacaoModel locacaoNova, ProdutoModel produto)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    int? quantidadeProduto = null;
                    if (locacaoAntiga != null)
                    {
                        quantidadeProduto = locacaoAntiga.QuantidadeProduto;
                        locacaoAntiga.QuantidadeProduto = null;
                        locacaoAntiga.ProdutoId = null;
                        locacaoAntiga.Produto = null;

                        context.LocacaoCXT.Update(locacaoAntiga);
                        context.SaveChanges();
                    }
                    
                    locacaoNova.Produto = produto;
                    locacaoNova.ProdutoId = produto.ProdutoId;
                    locacaoNova.QuantidadeProduto = quantidadeProduto;

                    context.LocacaoCXT.Update(locacaoNova);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar a locação");
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
