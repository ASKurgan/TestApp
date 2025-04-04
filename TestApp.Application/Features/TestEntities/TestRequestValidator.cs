using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Validators;
using TestApp.Domain.Entities;

namespace TestApp.Application.Features.TestEntities
{
    public class TestRequestValidator : AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            //RuleFor(t => t.Query)
            //    .MustBeEntityObject(s => TestEntity.Create(s.ToString()));
        }
    }
}
