using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Extensions;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class ApplicationUserProfileSeederEfConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasData(
                // admin User with Administrators Profile
                new UserProfile
                {
                    Id = Guid.Parse("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"),
                    ApplicationUserId = Guid.Parse("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"),
                    ProfileId = Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c")
                }
            );
        }
    }
}