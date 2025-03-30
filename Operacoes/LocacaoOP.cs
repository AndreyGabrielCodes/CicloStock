using CicloStock.Mapping;
using CicloStock.Models;

namespace CicloStock.Operacoes
{
    public class LocacaoOP
    {
        #region Locacao
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

        public static void Alterar(LocacaoModel locacao, LocacaoModel locacaoNova)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    locacao.Descricao = locacaoNova.Descricao;
                    locacao.Situacao = locacaoNova.Situacao;
                    locacao.QuantidadeProduto = locacaoNova.QuantidadeProduto;
                    locacao.Produto = locacaoNova.Produto;  
                    context.LocacaoCXT.Update(locacao);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar");
            }
        }

        public static void Remover(LocacaoModel locacao)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    context.LocacaoCXT.Remove(locacao);
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
