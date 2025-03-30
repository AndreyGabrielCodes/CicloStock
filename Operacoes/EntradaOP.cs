using CicloStock.Mapping;
using CicloStock.Models;

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
            try
            {
                using (var context = new CicloStockContext())
                {
                    entrada.Descricao = entradaNova.Descricao;
                    entrada.Situacao = entradaNova.Situacao;
                    entrada.DataInicio = entradaNova.DataInicio;
                    entrada.DataFim = entradaNova.DataFim;   
                    context.EntradaCXT.Update(entrada);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception($"Não foi possível alterar");
            }
        }

        public static void Remover(EntradaModel entrada)
        {
            try
            {
                using (var context = new CicloStockContext())
                {
                    context.EntradaCXT.Remove(entrada);
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
