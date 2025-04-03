using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Features.TestEntities;

namespace TestApp.Application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            //services.AddScoped<PCHandler>();
            //services.AddScoped<PublishProductHandler>();

            services.AddScoped<TestEntityHandler>();
            return services;
        }

    }
}
