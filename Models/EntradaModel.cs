using CicloStock.Utilitarios;

namespace CicloStock.Models
{
    public class EntradaModel
    {
        public int EntradaId { get; set; }
        public string Descricao { get; set; }
        public ICollection<EntradaLoteModel>? EntradaLotes { get; set; }
        public Enumerados.SituacaoEntrada Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
    public class EntradaLoteModel
    {
        public int EntradaLoteId { get; set; }
        public EntradaModel Entrada { get; set; }
        public int EntradaId { get; set; }
        public ICollection<EntradaLoteItemModel>? EntradaLoteItens { get; set; }
        public string Descricao { get; set; }
        public Enumerados.SituacaoEntradaLote Situacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
    public class EntradaLoteItemModel
    {
        public int EntradaLoteItemId { get; set; }
        public EntradaLoteModel EntradaLote { get; set; }
        public int EntradaLoteId { get; set; }
        public ProdutoModel Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

    }
}
