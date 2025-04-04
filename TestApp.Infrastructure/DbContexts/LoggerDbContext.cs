using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public DbSet<LogEntity> LogEntities => Set<LogEntity>();
        public LoggerDbContext(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LoggerConn"),
                b => b.MigrationsAssembly("TestApp.Infrastructure"));

            

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
