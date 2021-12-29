using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class UserGlobalPermissionEfConfig : IEntityTypeConfiguration<UserGlobalPermission>
    {
        public void Configure(EntityTypeBuilder<UserGlobalPermission> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasKey(t => new { t.ApplicationUserId, t.PermissionId});
        }
    }
}

