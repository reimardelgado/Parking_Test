using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class ProfileSeederEfConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasData(
                new List<Profile>
                {
                    new Profile(Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c"), "Administrators", "Usuario con todos los permisos"),
                    new Profile(Guid.Parse("9a51bd24-0778-4db3-bd09-dfb5929227cd"), "Managers", "Usuario que tiene puede gestionar los parqueaderos"),
                    new Profile(Guid.Parse("28046bd6-c5ee-4575-96f4-5e236f426ead"), "CommonUsers", "Usuario que sólo reservar parqueaderos"),
                    new Profile(Guid.Parse("28046fe6-b984-4c80-b1d2-8c3920973210"), "ReadOnly", "Usuario que puede ver todo dentro del backend pero sin poder realizar acción alguna"),
                }
            );
        }
    }
}

