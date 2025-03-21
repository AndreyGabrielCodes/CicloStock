namespace CicloStock.Models
{
    public class EntradaLoteModel
    {
        public int EntradaLoteId { get; set; }
        public string Descricao { get; set; }
        public Enum Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Cancelada { get; set; }
        public Enum? Inconsistencia { get; set; }
    }
}
