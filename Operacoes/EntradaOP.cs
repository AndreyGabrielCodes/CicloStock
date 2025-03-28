using CicloStock.Mapping;
using CicloStock.Models;
using CicloStock.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Operacoes
{
    public class EntradaOP
    {
        #region Entrada
        public static void Inserir()
        {
            using (var context = new CicloStockContext())
            {
                var entrada = new EntradaModel();
                entrada.Descricao = "teste";
                entrada.Situacao = Enumerados.SituacaoEntrada.Aberto;

                context.EntradaCXT.Add(entrada);
                context.SaveChanges();
            }
        }

        public static void Alterar()
        {

        }

        public static void Remover()
        {

        }

        public static void Consultar()
        {

        }

        #endregion

        #region EntradaLote

        public static void InserirLote()
        {

        }

        public static void AlterarLote()
        {

        }

        public static void RemoverLote()
        {

        }

        public static void ConsultarLote()
        {

        }

        #endregion
    }
}
