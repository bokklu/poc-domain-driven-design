﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using POC.DDD.Infra.Repositories;
using POC.DDD.Infra.Repositories.Abstractions;

namespace POC.DDD.Infra.Extensions
{
    public static class RegistryExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IBusinessRepository, BusinessRepository>();

            services
                .AddDbContext<BusinessContext>(options =>
                {
                    options.UseInMemoryDatabase("BusinessDb")
                        .EnableSensitiveDataLogging()
                        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });

            return services;
        }
    }
}