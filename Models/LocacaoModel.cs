using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class LocacaoModel
    {
        public int LocacaoId {  get; set; }
        public ProdutoModel? Produto { get; set; }
        public string Descricao {  get; set; }
        public Enumerados.SituacaoLocacao Situacao { get; set; }
        public int? QuantidadeProduto { get; set; }
    }

    public class LocacaoProdutoModel
    {
        public LocacaoModel Locacao { get; set; }
        public ProdutoModel Produto { get; set; }
    }
}
