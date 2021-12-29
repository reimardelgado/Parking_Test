using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class UserProfilesEfConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => new { t.ApplicationUser, t.ProfileId });
        }
    }
}

