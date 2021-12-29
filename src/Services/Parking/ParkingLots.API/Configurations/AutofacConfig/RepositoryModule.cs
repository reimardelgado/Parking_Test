using Autofac;
using ParkingLots.Domain.Interfaces.Repositories;
using ParkingLots.Infrastructure.Repositories;

namespace ParkingLots.API.Configurations.AutofacConfig
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfRepository>().As<IRepository>()
                .InstancePerLifetimeScope();
        }
    } 
}

