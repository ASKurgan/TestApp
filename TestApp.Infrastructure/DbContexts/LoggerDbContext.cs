using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Infrastructure.DbContexts
{
    public class LoggerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<LogEntity> LogEntities { get; set; }
        public LoggerDbContext(IConfiguration configuration, DbContextOptions<LoggerDbContext> dbContext) : base(dbContext)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.AddInterceptors(new DateInterceptor());
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LoggerConn"),
                b => b.MigrationsAssembly("TestApp.Infrastructure"));

            // optionsBuilder.UseSnakeCaseNamingConvention();

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(LoggerDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Write") ?? false);
        }
    }
}
