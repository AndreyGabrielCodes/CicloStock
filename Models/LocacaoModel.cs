namespace CicloStock.Models
{
    public class LocacaoModel
    {
        public int LocacaoId {  get; set; }
        public ProdutoModel Produto { get; set; }
        public string Descricao {  get; set; }
        public Enum Situacao { get; set; }
        public int? QuantidadeProduto { get; set; }
    }
}
