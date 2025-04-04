using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestApp.Domain.Common.Error;
using TestApp.Domain.Common;

namespace TestApp.Domain.Entities
{
    public class LogEntity  // : Entity
    {
        public LogEntity() { }
        public LogEntity(int statusCode, string method, string url)
        {
            StatusCode = statusCode;
            Url = Url;
            Method = method;
        }

        public long Id { get; set; }
        public string Method { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
