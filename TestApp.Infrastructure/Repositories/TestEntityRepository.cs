using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestApp.Domain.Common.Error;
using TestApp.Domain.Common;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.DbContexts;
using TestApp.Application.Features.TestEntities;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Infrastructure.Repositories
{
    public class TestEntityRepository : ITestEntityRepository
    {
        private readonly WriteDbContext _dbContext;

        public TestEntityRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(TestEntity testEntity, CancellationToken ct)
        {
            await _dbContext.TestEntities.AddAsync(testEntity, ct);
        }

        public async Task<IReadOnlyList<TestEntity>> GetAll(CancellationToken ct)
        {
            var testEntities = await _dbContext.TestEntities
                                           .ToListAsync(cancellationToken: ct);

            return testEntities;
        }

        public async Task<Result<TestEntity>> GetById(long id, CancellationToken ct)
        {
            var testEntity = await _dbContext.TestEntities
                                 .FirstOrDefaultAsync(te => te.Id == id, cancellationToken: ct);

            if (testEntity is null)
                return Errors.General.NotFound();

            return testEntity;
        }

        public async Task<Result<TestEntity>> GetByValue(string value, CancellationToken ct)
        {
            var testEntity = await _dbContext.TestEntities
              .FirstOrDefaultAsync(te => te.Value == value, cancellationToken: ct);

            if (testEntity is null)
                return Errors.General.NotFound();

            return testEntity;
        }


        // Entities

        //public async Task AddEntity(TestEntity testEntity, CancellationToken ct)
        //{
        //    await _dbContext.TestEntities.AddAsync(testEntity, ct);
        //}

        

      
    }

}
