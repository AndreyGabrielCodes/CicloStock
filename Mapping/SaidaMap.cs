using CicloStock.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CicloStock.Mapping
{
    public class SaidaMap : IEntityTypeConfiguration<SaidaModel>
    {
        public void Configure(EntityTypeBuilder<SaidaModel> builder)
        {
            builder.ToTable("Saida");

            builder.HasKey(x => x.SaidaId);
            builder.Property(x => x.SaidaId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Situacao)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.DataInicio)
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataFim)
                .HasColumnType("DATETIME");

        }
    }
}
