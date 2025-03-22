namespace CicloStock.Models
{
    public class LocacaoModel
    {
        public int LocacaoId {  get; set; }
        public string Descricao {  get; set; }
        public Enum Situacao { get; set; }
    }
}
