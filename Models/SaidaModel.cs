namespace CicloStock.Models
{
    public class SaidaModel
    {
        public int SaidaId { get; set; }
        public string Descricao { get; set; }
        public Enum Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
