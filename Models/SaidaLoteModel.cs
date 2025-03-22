namespace CicloStock.Models
{
    public class SaidaLoteModel
    {
        public int SaidaLoteId { get; set; }
        public string Descricao { get; set; }
        public Enum Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Enum? Inconsistencia { get; set; }
    }
}
