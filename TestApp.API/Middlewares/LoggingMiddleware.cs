using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;
        public LoggingMiddleware(RequestDelegate next, 
                                 IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                try 
                {
                    var scope = _scopeFactory.CreateScope();
                    var loggerDbContext = scope.ServiceProvider.GetRequiredService<LoggerDbContext>();
                    loggerDbContext.LogEntities.Add(new LogEntity()
                    {
                        StatusCode = context.Response.StatusCode,
                        Method = context.Request.Method,
                        Url = context.Request.Path
                    });

                    loggerDbContext.SaveChanges();
                }

                catch (Exception ex)
                {
                    // Так как это тестовое задание
                    // В случае ошибки при сохранении в бд просто задавливаем исключение
                    
                }

            }
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
