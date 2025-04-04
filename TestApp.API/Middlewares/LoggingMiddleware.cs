using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, LoggerDbContext loggerDbContext)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                loggerDbContext.Database.EnsureCreatedAsync();

                loggerDbContext.LogEntities.Add(new LogEntity()
                {
                    StatusCode = context.Response.StatusCode,
                    Method = context.Request.Method,
                    Url = context.Request.Path
                });

                loggerDbContext.SaveChanges();
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
