using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.SeedWork;

namespace ParkingLots.Infrastructure.SeederConfigurations
{
    public class PermissionSeederEfConfig: IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(
                new List<Permission>
                {
                    // Parking Lots
                    new Permission(Guid.Parse("b6855d79-4563-49d4-ab7b-b103c4626a5c"), "Parking:Parking:FullAccess", "Acceso total a los parqueaderos", "PARKING", PermissionTypes.Global),
                    new Permission(Guid.Parse("7b3af634-d525-4b07-adfe-c5c1bd7b2a3a"), "Parking:Parking:ReadOnlyAccess", "Acceso de sólo lectura a los parqueaderos", "PARKING", PermissionTypes.Global),
                
                    // Usuarios
                    new Permission(Guid.Parse("9a51bd24-0778-4db3-bd09-dfb5929227cd"), "Users:Profiles:FullAccess", "Acceso total a los perfiles disponibles", "USERS", PermissionTypes.Global),
                    new Permission(Guid.Parse("c37458ff-ec12-4f2c-b959-1637f37d2caa"), "Users:Profiles:ReadOnlyAccess", "Acceso de sólo lectura a los perfiles disponibles", "USERS", PermissionTypes.Global),
                
                    new Permission(Guid.Parse("b970bb7d-422e-4354-8e1c-c40b111dec51"), "Users:Managers:FullAccess", "Acceso total a los usuarios", "USERS", PermissionTypes.Scoped),
                    new Permission(Guid.Parse("3f16ee60-60e5-4517-8112-6ee8593f9d5b"), "Users:Managers:ReadOnlyAccess", "Acceso de sólo lectura a los usuarios", "USERS", PermissionTypes.Scoped),
                    new Permission(Guid.Parse("89b8a609-dfd9-4dd7-a124-fb3b0091dde5"), "Users:Managers:ReadEditAccess", "Acceso de lectura y edición a los usuarios", "USERS", PermissionTypes.Scoped),
                    new Permission(Guid.Parse("710282e5-a137-4df2-947a-aa7be3a64196"), "Users:Managers:ResendSignUp", "Capacidad para poder reenviar el correo de registro a los usuarios", "USERS", PermissionTypes.Scoped),
                }
            );
        }
    }
}

