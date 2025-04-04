using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Common;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.ReadModels;

namespace TestApp.Infrastructure.Queries.TestEntities.GetTestEntity.GetAll
{
    public class GetEntitiesQuery
    {
       private readonly ReadDbContext _context;

        public GetEntitiesQuery(ReadDbContext context)
        {
            _context = context;
        }

        public async Task <Result<IEnumerable<TestEntityReadModel>>> Handle(CancellationToken ct)
        {
            var entitiesResult = await _context.ReadEntities.ToListAsync(ct);

            if (entitiesResult is null)
                return Error.Errors.General.NotFound();
            return entitiesResult;
        }
    }
}
