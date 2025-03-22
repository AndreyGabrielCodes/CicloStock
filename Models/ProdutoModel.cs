using System.Runtime.InteropServices.Marshalling;

namespace CicloStock.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public Enum Situacao { get; set; }
        public Enum Categoria { get; set; }
        public string CodigoBarras { get; set; }
    }
}
