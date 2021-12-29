using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.EntityConfigurations
{
    public class ProfileEfConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(64)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.Property(t => t.DeletedAt);
        }
    }
}

