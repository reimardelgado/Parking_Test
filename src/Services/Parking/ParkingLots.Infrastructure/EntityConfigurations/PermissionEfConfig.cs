using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class PermissionEfConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                .HasMaxLength(64)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.ResourceCode)
                .HasMaxLength(64)
                .IsRequired()
                .IsUnicode(false);

            builder.HasIndex(t => t.Code)
                .IsUnique();

            builder.Metadata
                .FindNavigation(nameof(Permission.UserGlobalPermissions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}