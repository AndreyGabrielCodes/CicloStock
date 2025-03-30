using CicloStock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Mapping
{
    public class LocacaoMap : IEntityTypeConfiguration<LocacaoModel>
    {
        public void Configure(EntityTypeBuilder<LocacaoModel> builder)
        {
            builder.ToTable("Locacao");

            builder.HasKey(x => x.LocacaoId);
            builder.Property(x => x.LocacaoId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Situacao)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(x => x.QuantidadeProduto)
                .HasColumnType("INT")
                .HasDefaultValue(0);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Locacoes);
                //.HasForeignKey(x => x.Produto)
                //.IsRequired(false);
        }
    }
}
