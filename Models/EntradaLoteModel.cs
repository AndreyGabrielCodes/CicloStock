using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class EntradaLoteModel
    {
        public int EntradaLoteId { get; set; }
        public EntradaModel Entrada { get; set; }
        public string Descricao { get; set; }
        public Enumerados Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Enumerados? Inconsistencia { get; set; }
    }
}
