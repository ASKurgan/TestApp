using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Features.TestEntities;
using TestApp.Application.Interfaces.DataAccess;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Providers;
using TestApp.Infrastructure.Queries.TestEntities.GetTestEntity.GetAll;
using TestApp.Infrastructure.Repositories;

namespace TestApp.Infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDataStorages(configuration);
            services.AddRepositories();
            services.AddQueries();

            return services;
        }


        private static IServiceCollection AddDataStorages(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddScoped<ITransaction, Transaction>();
            services.AddScoped<WriteDbContext>();
            services.AddScoped<ReadDbContext>();
            services.AddSingleton<LoggerDbContext>();
           
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestEntityRepository, TestEntityRepository>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<GetEntitiesQuery>();
           
            return services;
        }

    }
}
