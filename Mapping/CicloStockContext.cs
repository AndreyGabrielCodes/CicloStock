using Microsoft.EntityFrameworkCore;
using CicloStock.Models;

namespace CicloStock.Mapping
{
    public class CicloStockContext : DbContext
    {
        public DbSet<EntradaModel> EntradaCXT { get; set; }
        public DbSet<EntradaLoteModel> EntradaLoteCXT { get; set; }
        public DbSet<LocacaoModel> LocacaoCXT { get; set; }
        public DbSet<ProdutoModel> ProdutoCXT { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=CicloStock;User ID=sqlserver;Password=sqlserver;Trusted_Connection=False;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
            modelBuilder.ApplyConfiguration(new EntradaMap());
            modelBuilder.ApplyConfiguration(new EntradaLoteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new LocacaoMap());
        }
    }
}
