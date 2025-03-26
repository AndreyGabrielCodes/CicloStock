using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class SaidaModel
    {
        public int SaidaId { get; set; }
        public string Descricao { get; set; }
        public List<SaidaLoteModel> SaidaLotes { get; } = new List<SaidaLoteModel>();
        public Enumerados Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
