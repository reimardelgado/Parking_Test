using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class ProfilePermissionsSeederEfConfig : IEntityTypeConfiguration<ProfilePermission>
    {
        public void Configure(EntityTypeBuilder<ProfilePermission> builder)
        {
            // Administrador
            builder.HasData(
                new List<ProfilePermission>
                {
                    // Administrators
                    new ProfilePermission(Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c"), Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c")), // Parking:Parking:FullAccess
                    new ProfilePermission(Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c"), Guid.Parse("9a51bd24-0778-4db3-bd09-dfb5929227cd")), // Users:Profiles:FullAccess
                    new ProfilePermission(Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c"), Guid.Parse("b970bb7d-422e-4354-8e1c-c40b111dec51")), // Users:Members:FullAccess
                    
                    // 
                });
        }
    }
}

