using System.Reflection;
using Autofac;
using MediatR;
using ParkingLots.Application.Commands.LoginCommands;
using ParkingLots.Infrastructure.Behaviors;

namespace ParkingLots.API.Configurations.AutofacConfig
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(LoginUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            // builder.RegisterAssemblyTypes(typeof(ReadUserService).GetTypeInfo().Assembly)
            //     .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            // Register all the Notification classes (they implement INotification) in assembly holding the Notifications
            // builder.RegisterAssemblyTypes(typeof(LocationCreatedDomainEvent).GetTypeInfo().Assembly)
            //     .AsClosedTypesOf(typeof(INotificationHandler<>))
            //     .AsImplementedInterfaces();

            // Register the Command's Validators (Validators based on FluentValidation library)
            // builder
            //     .RegisterAssemblyTypes(typeof(CreateProgramCommandValidator).GetTypeInfo().Assembly)
            //     .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //     .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;
            });
            
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}

