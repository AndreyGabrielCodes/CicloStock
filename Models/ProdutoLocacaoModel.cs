namespace CicloStock.Models
{
    public class ProdutoLocacaoModel
    {
        public int ProdutoLocacaoId { get; set; }
        public int ProdutoId { get; set; }
        public int LocacaoId { get; set; }
        public int QuantidadeProduto { get; set; }
    }
}
