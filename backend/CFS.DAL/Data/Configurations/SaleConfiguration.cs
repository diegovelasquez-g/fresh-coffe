using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.SaleId).HasName("Sales_pkey");

            builder.Property(e => e.SaleId).HasColumnName("saleId");
            builder.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            builder.Property(e => e.InvoiceNumber)
                .HasMaxLength(100)
                .HasColumnName("invoiceNumber");
            builder.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("paymentMethod");
            builder.Property(e => e.SaleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("saleDate");
            builder.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("totalAmount");
            builder.Property(e => e.UserId).HasColumnName("userId");

            builder.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Sales_userId_fkey");
        }
    }
}
