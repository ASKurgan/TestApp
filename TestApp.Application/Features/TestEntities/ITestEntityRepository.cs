using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Common;
using TestApp.Domain.Entities;

namespace TestApp.Application.Features.TestEntities
{
    public interface ITestEntityRepository
    {
        Task Add(TestEntity testEntity, CancellationToken ct);
        Task<Result<TestEntity>> GetById(long id, CancellationToken ct);
        Task<Result<TestEntity>> GetByValue(string name, CancellationToken ct);
        Task<IReadOnlyList<TestEntity>> GetAll(CancellationToken ct);
        Task<Result> DeleteAll(IReadOnlyList<TestEntity> testEntities,CancellationToken ct);
        // Task AddEntity(TestEntity testEntity, CancellationToken cancellationToken);
    }
}
