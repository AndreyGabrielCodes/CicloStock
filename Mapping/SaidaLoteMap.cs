using CicloStock.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CicloStock.Mapping
{
    public class SaidaLoteMap : IEntityTypeConfiguration<SaidaLoteModel>
    {
        public void Configure(EntityTypeBuilder<SaidaLoteModel> builder)
        {
            builder.ToTable("SaidaLote");

            builder.HasKey(x => x.SaidaLoteId);
            builder.Property(x => x.SaidaLoteId)
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

            builder.Property(x => x.Inconsistencia)
                .HasColumnType("INTEGER");

            builder.HasOne(x => x.Saida)
                .WithMany(x => x.SaidaLotes)
                .HasForeignKey(x => x.Saida)
                .IsRequired(false);
        }
    }
}
