using System;
using System.Reflection;
using AutoMapper;
using DomainValidation.Interfaces.Validation;
using ITP_Cli.Engine.Mapping;
using ITP_Cli.Infra.Bus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace ITP_Cli.Engine.Extensions
{
    public static class ParserBootstrapper
    {
        public static IServiceCollection AddParserSystem(this IServiceCollection services, IConfiguration configuration,
            Type migrateAssemblyType)
        {
            var assemblies = new[]
            {
                Assembly.Load("ITP-Cli.Engine"),
                Assembly.Load("ITP-Cli.Infra")
            };

            var mappingConfig = new MapperConfiguration(mappingConfig =>
            {
                mappingConfig.AddProfile(new TsvItemProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(configuration);
            services.AddOptions();
            var section = configuration.GetSection("ComplexitySettings");

            services.Configure<ComplexitySettings>(section);

            services.AddSingleton(mapper);
            services.AddMediatR(migrateAssemblyType.GetType());

            services.Scan(scanner =>
                scanner.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo(typeof(INotificationHandler<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IMediatorHandler)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
            return services;
        }
    }
}