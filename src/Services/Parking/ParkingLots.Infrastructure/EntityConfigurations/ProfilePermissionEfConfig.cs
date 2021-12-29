using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class ProfilePermissionEfConfig : IEntityTypeConfiguration<ProfilePermission>
    {
        public void Configure(EntityTypeBuilder<ProfilePermission> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasKey(t => new { t.ProfileId, t.PermissionId});
            builder.Property(t => t.ProfileId).IsRequired();
            builder.Property(t => t.PermissionId).IsRequired();
        }
    }
}

