using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces.DataAccess;
using TestApp.Domain.Entities;

namespace TestApp.Infrastructure.DbContexts
{
    public class WriteDbContext : DbContext, ITransaction
    {
        private readonly IConfiguration _configuration;



        public WriteDbContext(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _configuration = configuration;

        }

    

        public DbSet<TestEntity> TestEntities => Set<TestEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.AddInterceptors(new DateInterceptor());
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TestApp"),
                b => b.MigrationsAssembly("TestApp.Infrastructure"));

           // optionsBuilder.UseSnakeCaseNamingConvention();

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(WriteDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Write") ?? false);
        }
    }

}
