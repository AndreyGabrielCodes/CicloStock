using CicloStock.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CicloStock.Mapping
{
    public class EntradaLoteMap : IEntityTypeConfiguration<EntradaLoteModel>
    {
        public void Configure(EntityTypeBuilder<EntradaLoteModel> builder)
        {
            builder.ToTable("EntradaLote");

            builder.HasKey(x => x.EntradaLoteId);
            builder.Property(x => x.EntradaLoteId)
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
                .HasColumnType("DATE");

            builder.Property(x => x.DataFim)
                .HasColumnType("DATE");

            builder.Property(x => x.Inconsistencia)
                .HasColumnType("INTEGER");

            builder.HasOne(x => x.Entrada)
                .WithMany(x => x.EntradaLotes)
                .IsRequired(false);
        }
    }
}
