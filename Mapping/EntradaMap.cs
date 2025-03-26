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

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Situacao)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(x => x.DataInicio)
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.DataFim)
                .HasColumnType("DATETIME");
        }
    }
}
