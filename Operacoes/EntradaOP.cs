using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;

namespace CicloStock.Operacoes
{
    public class EntradaOP
    {
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

    }
}
