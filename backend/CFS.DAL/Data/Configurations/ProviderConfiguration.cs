using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(e => e.ProviderId).HasName("Providers_pkey");

            builder.Property(e => e.ProviderId).HasColumnName("providerId");
            builder.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("createBy");
            builder.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            builder.Property(e => e.IsActive).HasColumnName("isActive");
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(8)
                .HasColumnName("phoneNumber");
            builder.Property(e => e.ProviderName)
                .HasMaxLength(50)
                .HasColumnName("providerName");
            builder.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("updateBy");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateDate");
        }
    }
}
