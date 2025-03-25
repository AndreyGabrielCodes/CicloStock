using CicloStock.Utilitarios;
using System.Runtime.InteropServices.Marshalling;

namespace CicloStock.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public Enumerados Situacao { get; set; }
        public string CodigoBarras { get; set; }
    }
}
