using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId).HasName("Products_pkey");

            builder.Property(e => e.ProductId).HasColumnName("productId");
            builder.Property(e => e.BarCode)
                .HasMaxLength(100)
                .HasColumnName("barCode");
            builder.Property(e => e.CategoryId).HasColumnName("categoryId");
            builder.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("createBy");
            builder.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            builder.Property(e => e.IsActive).HasColumnName("isActive");
            builder.Property(e => e.IsStockEnabled).HasColumnName("isStockEnabled");
            builder.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            builder.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("productName");
            builder.Property(e => e.ProviderId).HasColumnName("providerId");
            builder.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("updateBy");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateDate");

            builder.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("Products_categoryId_fkey");

            builder.HasOne(d => d.Provider).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("Products_providerId_fkey");
        }
    }
}
