using CicloStock.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicloStock.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.ProdutoId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Situacao)
                .IsRequired()
                .HasColumnType("INT");
            
            builder.Property(x => x.CodigoBarras)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);

        }
    }
}
