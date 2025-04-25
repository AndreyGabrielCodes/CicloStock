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
                .HasColumnType("INT");

            builder.Property(x => x.DataInicio)
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataFim)
                .HasColumnType("DATETIME");
        }
    }

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
                .HasColumnType("INT");

            builder.Property(x => x.DataInicio)
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataFim)
                .HasColumnType("DATETIME");

            builder.HasOne(x => x.Entrada)
                .WithMany(x => x.EntradaLotes)
                .HasForeignKey(x => x.EntradaId)
                .IsRequired(false);
        }
    }

    public class EntradaLoteItemMap : IEntityTypeConfiguration<EntradaLoteItemModel>
    {
        public void Configure(EntityTypeBuilder<EntradaLoteItemModel> builder)
        {
            builder.ToTable("EntradaLoteItem");

            builder.HasKey(x => x.EntradaLoteItemId);
            builder.Property(x => x.EntradaLoteItemId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasOne(x => x.EntradaLote)
                .WithMany(x => x.EntradaLoteItens)
                .HasForeignKey(x => x.EntradaLoteId)
                .IsRequired(true);

            builder.HasOne(x => x.Produto);

            builder.Property(x => x.Quantidade)
                .HasColumnType("INT")
                .HasDefaultValue(0)
                .IsRequired(true);
        }
    }
}
