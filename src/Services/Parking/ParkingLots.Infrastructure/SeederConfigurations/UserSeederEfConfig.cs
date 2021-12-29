using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Extensions;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class UserSeederEfConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser { Id = Guid.Parse("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"), UserName = "admin", Password = "P@55w0rd".ToMd5Hash() }
            );
        }
    }
}