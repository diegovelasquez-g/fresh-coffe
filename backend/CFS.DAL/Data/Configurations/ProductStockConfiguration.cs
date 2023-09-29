using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasKey(e => e.StockId).HasName("ProductStock_pkey");

            builder.ToTable("ProductStock");

            builder.Property(e => e.StockId).HasColumnName("stockId");
            builder.Property(e => e.LastUpdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastUpdate");
            builder.Property(e => e.ProductId).HasColumnName("productId");
            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.HasOne(d => d.Product).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("ProductStock_productId_fkey");
        }
    }
}
