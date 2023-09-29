using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.SaleId).HasName("Tickets_pkey");

            builder.Property(e => e.SaleId)
                .ValueGeneratedNever()
                .HasColumnName("saleId");
            builder.Property(e => e.IssueDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("issueDate");
            builder.Property(e => e.TicketNumber)
                .HasMaxLength(100)
                .HasColumnName("ticketNumber");

            builder.HasOne(d => d.Sale).WithOne(p => p.Ticket)
                .HasForeignKey<Ticket>(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tickets_saleId_fkey");
        }
    }
}
