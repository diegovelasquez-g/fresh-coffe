using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId).HasName("Categories_pkey");

            builder.Property(e => e.CategoryId).HasColumnName("categoryId");
            builder.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
            builder.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("createBy");
            builder.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.IsActive).HasColumnName("isActive");
            builder.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("updateBy");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateDate");
        }
    }
}
