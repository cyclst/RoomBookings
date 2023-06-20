using System.Reflection;
using Autofac;
using AutoMapper;
using MediatR;
using RoomBookings.Common.Application.Commands;
using RoomBookings.Common.Application.DomainEvents;
using RoomBookings.Common.Application.Helpers;
using RoomBookings.CommonQueries;

namespace RoomBookings.Common.Application;

public class AutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .SingleInstance();

        builder.RegisterType<MediatRCommandDispatcher>().As<ICommandDispatcher>().SingleInstance();
        builder.RegisterType<MediatRQueryDispatcher>().As<IQueryDispatcher>().SingleInstance();
        builder.RegisterType<MediatRDomainEventPublisher>().As<IDomainEventPublisher>().SingleInstance();

        var assemblies = System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies("RoomBookings").Distinct().ToArray();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("CommandHandler"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("DomainEventHandler"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("QueryHandler"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("Gateway"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.Name.EndsWith("PipelineBehaviour"))
            .AsImplementedInterfaces();


        var assembliesTypes = assemblies.SelectMany(x => x.GetTypes())
            .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
            .Distinct();

        var autoMapperProfiles = assembliesTypes
            .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

        builder.Register(ctx => new MapperConfiguration(cfg =>
        {
            foreach (var profile in autoMapperProfiles)
            {
                cfg.AddProfile(profile);
            }
        }));

        //// Hook up automapper
        //// https://github.com/AutoMapper/AutoMapper/issues/1109
        //builder.Register(c => new MapperConfiguration(cfg =>
        //{
        //    foreach (var profile in c.Resolve<IEnumerable<Profile>>())
        //        cfg.AddProfile(profile);
        //}))
        //    .AsSelf()
        //    .SingleInstance();

        builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();
    }
}
