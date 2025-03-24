using Microsoft.EntityFrameworkCore;
using CicloStock.Models;

namespace CicloStock.Mapping
{
    public class CicloStockContext : DbContext
    {
        public DbSet<EntradaModel> Entrada { get; set; }
        public DbSet<EntradaLoteModel> EntradaLote { get; set; }
        public DbSet<SaidaModel> Saida { get; set; }
        public DbSet<SaidaLoteModel> SaidaLote { get; set; }
        public DbSet<LocacaoModel> Locacao { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ProdutoLocacaoModel> ProdutoLocacao { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=CicloStock;User ID=sa;Password=1q2w3e4r@#$");
        }

    }
}
