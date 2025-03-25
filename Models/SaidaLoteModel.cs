using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class SaidaLoteModel
    {
        public int SaidaLoteId { get; set; }
        public SaidaModel Saida { get; set; }
        public string Descricao { get; set; }
        public Enumerados Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Enumerados? Inconsistencia { get; set; }
    }
}
