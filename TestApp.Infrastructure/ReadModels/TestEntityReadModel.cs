using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Infrastructure.ReadModels
{
    public class TestEntityReadModel
    {
        public long Id { get; init; }
        public int Code { get; init; }
        public string Value { get; init; } = string.Empty;
    }
}
