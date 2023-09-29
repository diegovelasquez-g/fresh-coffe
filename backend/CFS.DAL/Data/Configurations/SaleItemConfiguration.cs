using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFS.DAL.Data.Configurations
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(e => e.SaleItemId).HasName("SaleItems_pkey");

            builder.Property(e => e.SaleItemId).HasColumnName("saleItemId");
            builder.Property(e => e.ProductId).HasColumnName("productId");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.SaleId).HasColumnName("saleId");
            builder.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");
            builder.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unitPrice");

            builder.HasOne(d => d.Product).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("SaleItems_productId_fkey");

            builder.HasOne(d => d.Sale).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("SaleItems_saleId_fkey");
        }
    }
}
