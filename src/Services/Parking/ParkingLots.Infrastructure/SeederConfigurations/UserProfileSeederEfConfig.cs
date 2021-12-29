using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class UserProfileSeederEfConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasData(
                new List<UserProfile>
                {
                    new UserProfile(){
                        ApplicationUserId = Guid.Parse("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"),
                        ProfileId = Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c")
                    }
                }
            );
        }
    }
}
