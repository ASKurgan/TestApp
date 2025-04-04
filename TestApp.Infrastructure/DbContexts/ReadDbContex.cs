using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces.DataAccess;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.ReadModels;

namespace TestApp.Infrastructure.DbContexts
{
    public class ReadDbContext : DbContext, ITransaction
    {
        private readonly IConfiguration _configuration;



        public ReadDbContext(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _configuration = configuration;

        }



        public DbSet<TestEntityReadModel> ReadEntities => Set<TestEntityReadModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.AddInterceptors(new DateInterceptor());
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TestApp"));


            // optionsBuilder.UseSnakeCaseNamingConvention();

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(WriteDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Read") ?? false);
        }
    }


}
