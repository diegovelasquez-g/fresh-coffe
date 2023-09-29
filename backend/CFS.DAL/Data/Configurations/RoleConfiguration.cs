using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFS.DAL.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.RoleId).HasName("Roles_pkey");

            builder.Property(e => e.RoleId).HasColumnName("roleId");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.IsActive).HasColumnName("isActive");
            builder.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("roleName");
        }
    }
}
