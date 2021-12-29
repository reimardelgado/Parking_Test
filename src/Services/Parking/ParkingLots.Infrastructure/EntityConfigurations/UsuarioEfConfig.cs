using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class ApplicationUserEfConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Metadata
                .FindNavigation(nameof(ApplicationUser.UserProfiles))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}