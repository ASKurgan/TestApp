using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces.DataAccess;
using TestApp.Domain.Common;

namespace TestApp.Application.Features.TestEntities
{
    public class TestEntityHandler
    {
        private readonly ITestEntityRepository _testEntity;
        private readonly ITransaction _transaction;

        public TestEntityHandler(ITestEntityRepository testEntity, ITransaction transaction)
        {
            _testEntity = testEntity;
            _transaction = transaction;
        }

        public async Task<Result<IEnumerable<long>>> Handle(TestRequest command, CancellationToken ct)
        {
            var entities = new List<Domain.Entities.TestEntity>();
            var entitiesId = new List<long>();
            var entityResult = Domain.Entities.TestEntity.Create(command.Queries[0]);
            
            if (entityResult.IsFailure)
            {
                return entityResult.Error;
            }
            
            foreach (var query in command.Queries)
            {
                entityResult = Domain.Entities.TestEntity.Create(query);

                if (entityResult.IsFailure)
                {
                    return entityResult.Error;
                }
                await _testEntity.Add(entityResult.Value, ct);
                await _transaction.SaveChangesAsync(ct);
                entitiesId.Add(entityResult.Value.Id);
            }


            await _transaction.SaveChangesAsync(ct);

            return entitiesId;
        }
    }
}
