using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Utilitarios
{
    public class Enumerados
    {
        public enum SituacaoEntrada : short 
        {
            Aberto = 0,
            EmAndamento = 1,
            Concluido = 2,
            Cancelado = 3,
        } 
        
        public enum SituacaoSaida : short 
        {
            Aberto = 0,
            EmAndamento = 1,
            Concluido = 2,
            Cancelado = 3,
        }
        
        public enum Categoria : short
        {
            Pereciveis = 1,
            NaoPereciveis = 2,

        }
    }
}
