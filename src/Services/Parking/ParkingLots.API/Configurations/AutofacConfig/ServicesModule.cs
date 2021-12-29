using Autofac;
using ParkingLots.Domain.Interfaces.Services;
using ParkingLots.Infrastructure.Security;

namespace ParkingLots.API.Configurations.AutofacConfig
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtTokenService>()
                .As<IJwtTokenService>()
                .InstancePerLifetimeScope();
        }
    }
}

