using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Models
{
    public class EntradaLoteItemModel
    {
        public int EntradaLoteItemId {  get; set; }
        public EntradaLoteModel EntradaLote { get; set; }
        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }

    }
}
