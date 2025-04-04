using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestApp.Domain.Common.Error;
using TestApp.Domain.Common;

namespace TestApp.Domain.Entities
{
    public class TestEntity : Entity
    {
        private const string Separator = ":";
        private TestEntity() { }
        private TestEntity(int code, string value)
        {
            Code = code;
            Value = value;
        }

        public int Code { get; private set; }
        public string Value { get; private set; } = string.Empty;

        public static Result<TestEntity> Create(string query)
        {

            var dataChars = query.ToCharArray();
            if (!dataChars.Contains(':'))
                return Errors.General.ValueIsInvalid(query);

            var data = query.Split([Separator], StringSplitOptions.RemoveEmptyEntries);
            if (data.Length < 2)
                return Errors.General.ValueIsInvalid(query);


            if (Int32.TryParse(data[0], out int code) && data[1].IsEmpty() == false)
            {
                var value = data[1];
                return new TestEntity(code, value);
            }

            return Errors.General.ValueIsInvalid(query);

        }
    }

}
