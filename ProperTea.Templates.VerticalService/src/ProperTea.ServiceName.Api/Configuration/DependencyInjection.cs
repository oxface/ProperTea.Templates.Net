using FluentValidation;
using ProperTea.ProperCqrs;
using ProperTea.ServiceName.Application.AggregateRootNames.Commands;
using ProperTea.ServiceName.Domain.AggregateRootNames;
using ProperTea.ServiceName.Infrastructure.Persistence;
using ProperTea.Shared.Application;
using ProperTea.Shared.Domain;
using ProperTea.Shared.Domain.Events;
using ProperTea.Shared.Infrastructure.Events;
using ProperTea.Shared.Infrastructure.Persistence;

namespace ProperTea.ServiceName.Api.Configuration;

public static class DomainServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<AggregateRootName>()
            .AddClasses(classes => classes.AssignableTo(typeof(IDomainService)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateUserCommandHandler).Assembly);

        services.Scan(scan => scan
            .FromAssemblyOf<CreateUserCommandHandler>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<CreateUserCommandHandler>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<CreateUserCommandHandler>()
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Decorate(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
        services.Decorate(typeof(ICommandHandler<,>), typeof(ValidationCommandHandlerDecorator<,>));

        services.Scan(scan => scan
            .FromAssemblyOf<AggregateRootNameCreatedDomainEvent>()
            .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<AggregateRootNameRepository>()
            .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }
}