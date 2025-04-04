using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces.DataAccess;
using TestApp.Domain.Common;
using TestApp.Domain.Entities;

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

        public async Task<Result<IEnumerable<long>>> Handle(object [] objects, CancellationToken ct)
        {
            var testEntities = await _testEntity.GetAll(ct);

            if (testEntities != null)
            {
               await _testEntity.DeleteAll(testEntities,ct);
               await _transaction.SaveChangesAsync(ct);
            }
            var entitiesId = new List<long>();
            var entities = new List<Domain.Entities.TestEntity>();

            foreach (var item in objects)
            {
                var s = item.ToString();
                if (s == null)
                    return Error.Errors.General.ValueIsInvalid();
               
                s = s.Replace("\"", "").Replace("{", "").Replace("}", "");


                var entityResult = TestEntity.Create(s);
                
                if (entityResult.IsFailure)
                {
                    return entityResult.Error;
                }

                var entity = entityResult.Value;
                entities.Add(entity);
            }

            entities.OrderBy(e => e.Code);
            
            foreach (var testEntity in entities)
            {
                await  _testEntity.Add(testEntity, ct);
                await _transaction.SaveChangesAsync(ct);
                entitiesId.Add(testEntity.Id);
            }

            return entitiesId;
        }

      }
    }

