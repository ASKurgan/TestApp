using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace TestApp.API.Extensions
{
    public static class ApiExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new()
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
            });
        }
    }
}
