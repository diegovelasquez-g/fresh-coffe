using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId).HasName("Users_pkey");

            builder.Property(e => e.UserId).HasColumnName("userId");
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
            builder.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
            builder.Property(e => e.RoleId).HasColumnName("roleId");
            builder.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("updateBy");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateDate");
            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");

            builder.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("Users_roleId_fkey");
        }
    }
}
