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
    public class EntradaLoteItemMap : IEntityTypeConfiguration<EntradaLoteItemModel>
    {
        public void Configure(EntityTypeBuilder<EntradaLoteItemModel> builder)
        {
            builder.ToTable("EntradaLoteItem");

            builder.HasKey(x => x.EntradaLoteItemId);
            builder.Property(x => x.EntradaLoteItemId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasOne(x => x.Produto);

            builder.HasOne(x => x.EntradaLote)
                .WithMany(x => x.EntradaLoteItens)
                .IsRequired(true);

            builder.Property(x => x.Quantidade)
                .HasColumnType("INT")
                .HasDefaultValue(0)
                .IsRequired(true);
        }
    }
}
