using CicloStock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicloStock.Mapping
{
    public class EntradaMap : IEntityTypeConfiguration<EntradaModel>
    {
        public void Configure(EntityTypeBuilder<EntradaModel> builder)
        {
            builder.ToTable("Entrada");

            builder.HasKey(x => x.EntradaId);
            builder.Property(x => x.EntradaId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
        }
    }
}
