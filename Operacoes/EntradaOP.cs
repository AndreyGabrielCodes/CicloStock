using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;

namespace CicloStock.Operacoes
{
    public class EntradaOP
    {
        #region Entrada
        public static void Inserir(EntradaModel entrada)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    context.EntradaCXT.Add(entrada);
                    context.SaveChanges();
                }
                catch 
                {
                    throw new Exception($"Não foi possível inserir o registro");
                }
            }
        }

        public static void Alterar(EntradaModel entrada, EntradaModel entradaNova)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    entrada.Descricao = entradaNova.Descricao;
                    entrada.Situacao = entradaNova.Situacao;
                    entrada.DataInicio = entradaNova.DataInicio;
                    entrada.DataFim = entradaNova.DataFim;
                    context.EntradaCXT.Update(entrada);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível alterar");
                }
            }
        }

        public static void AlterarSituacao(EntradaModel entrada, Enumerados.SituacaoEntrada situacaoNova)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    entrada.Situacao = situacaoNova;
                    context.EntradaCXT.Update(entrada);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível alterar");
                }
            }
        }

        public static void Remover(EntradaModel entrada)
        {
            using (var context = new CicloStockContext())
            {

                try
                {
                    context.EntradaCXT.Remove(entrada);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível remover");
                }
                    
            } 
        }

        public static List<EntradaModel> ListarEntradas()
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.EntradaCXT.ToList();
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
                    var entrada = context.EntradaCXT.Where(x => x.EntradaId == id && x.Situacao != Enumerados.SituacaoEntrada.Cancelado).FirstOrDefault();
                    if (entrada == null)
                        return false;

                    return true;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar o Id");
                }
            }
        }

        public static EntradaModel RetornarEntrada(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var entrada = context.EntradaCXT.Where(x => x.EntradaId == id).FirstOrDefault();
                    return entrada;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar registros");
                }
            }
        }

        #endregion

        #region Lote

        public static List<EntradaLoteModel> ListarLotes()
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.EntradaLoteCXT.ToList();
                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros");
                }
            }
        }

        public static List<EntradaLoteItemModel> ListarLotesItens()
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var lista = context.EntradaLoteItemCXT.ToList();
                    return lista;
                }
                catch
                {
                    throw new Exception($"Não foi possível visualizar registros");
                }
            }
        }

        public static bool VerificarIdLote(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var entrada = context.EntradaLoteCXT.Where(x => x.EntradaLoteId == id && x.Situacao != Enumerados.SituacaoEntradaLote.Cancelado).FirstOrDefault();

                    if (entrada == null)
                        return false;

                    return true;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar o Id");
                }
            }
        }

        public static void InserirLote(EntradaLoteModel entradaLote, EntradaModel entrada)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    //Attach faz com que o EF entenda a entrada como já existente, ao invés de criar uma nova
                    context.EntradaCXT.Attach(entrada);
                    entradaLote.Entrada = entrada;
                    entradaLote.EntradaId = entrada.EntradaId;
                    context.EntradaLoteCXT.Add(entradaLote);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível inserir o registro");
                }
            }
        }

        public static void InserirItemLote(EntradaLoteItemModel entradaLoteItem, EntradaLoteModel entradaLote, ProdutoModel produto)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var entradaLoteItemExistente = context.EntradaLoteItemCXT
                        .Where(x => x.EntradaLoteId == entradaLoteItem.EntradaLoteId && x.ProdutoId == entradaLoteItem.ProdutoId)
                        .FirstOrDefault();

                    if (entradaLoteItemExistente != null)
                    {
                        entradaLoteItemExistente.Quantidade += entradaLoteItem.Quantidade;
                        context.EntradaLoteItemCXT.Update(entradaLoteItemExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.EntradaLoteCXT.Attach(entradaLote);
                        context.ProdutoCXT.Attach(produto);
                        entradaLoteItem.EntradaLote = entradaLote;
                        entradaLoteItem.EntradaLoteId = entradaLote.EntradaLoteId;
                        entradaLoteItem.Produto = produto;
                        entradaLoteItem.ProdutoId = produto.ProdutoId;
                        context.EntradaLoteItemCXT.Add(entradaLoteItem);
                        context.SaveChanges();
                    }
                }
                catch 
                {
                    throw new Exception($"Não foi possível inserir o registro");
                }
            }
        }

        public static EntradaLoteModel RetornarEntradaLote(int id)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var entrada = context.EntradaLoteCXT.Where(x => x.EntradaLoteId == id).FirstOrDefault();
                    return entrada;
                }
                catch
                {
                    throw new Exception($"Não foi possível consultar registros");
                }
            }
        }

        public static void AlterarSituacaoLote(EntradaLoteModel entrada, Enumerados.SituacaoEntradaLote situacaoNova)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    entrada.Situacao = situacaoNova;
                    context.EntradaLoteCXT.Update(entrada);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível alterar");
                }
            }
        }

        public static void ExcluirItensLote(EntradaLoteModel entrada)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var itens = context.EntradaLoteItemCXT.Where(x => x.EntradaLoteId == entrada.EntradaLoteId).ToList();
                    context.RemoveRange(itens);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Não foi possível alterar");
                }
            }
        }

        public static bool ProdutoExisteLoteItem(ProdutoModel produto)
        {
            using (var context = new CicloStockContext())
            {
                try
                {
                    var produtoEmLote = context.EntradaLoteItemCXT.Where(x => x.Produto.ProdutoId == produto.ProdutoId).FirstOrDefault();

                    if (produtoEmLote != null)
                        return true;

                    return false;
                }
                catch
                {
                    throw new Exception($"Não foi possível alterar");
                }
            }
        }

        #endregion
    }
}
