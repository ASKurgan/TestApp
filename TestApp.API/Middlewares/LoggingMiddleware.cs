using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.API.Middlewares
{
    //public class LoggingMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly LoggerDbContext _dbContext;
    //    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, LoggerDbContext dbContext)
    //    {
    //        _next = next;
    //        _dbContext = dbContext;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //        }
    //        finally
    //        {
                

    //            _dbContext.LogEntities.Add(new LogEntity()
    //            {
    //                StatusCode = context.Response.StatusCode,
    //                Method = context.Request.Method,
    //                Url = context.Request.Path
    //            });

    //            _dbContext.SaveChanges();
    //        }
    //    }
    //}

    //public static class LoggingMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<LoggingMiddleware>();
    //    }
    //}
}
