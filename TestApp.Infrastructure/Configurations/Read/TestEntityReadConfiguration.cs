using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.ReadModels;

namespace TestApp.Infrastructure.Configurations.Read
{
    public class TestEntityReadConfiguration : IEntityTypeConfiguration<TestEntityReadModel>
    {
        public void Configure(EntityTypeBuilder<TestEntityReadModel> builder)
        {
            builder.ToTable("test_entity");
            
            builder.HasKey(t => t.Id);
        }
    }
}
