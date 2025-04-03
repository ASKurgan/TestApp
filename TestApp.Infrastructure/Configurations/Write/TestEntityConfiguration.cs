using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Infrastructure.Configurations.Write
{
    public class TestEntityConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.ToTable("test_entity");
            builder.HasKey(t => t.Id);
        }
    }
}
