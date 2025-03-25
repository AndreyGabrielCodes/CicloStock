using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class EntradaModel
    {
        public int EntradaId { get; set; }
        public string Descricao { get; set; }
        public Enumerados Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
