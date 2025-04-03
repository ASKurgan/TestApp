using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Interfaces.DataAccess
{
    public interface ITransaction
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
