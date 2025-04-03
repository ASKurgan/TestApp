using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Common;
using static TestApp.Domain.Common.Error;

namespace TestApp.Application.Validators
{
    public static class CustomValidators
    {

        public static IRuleBuilderOptions<T, TElement> MustBeEntityObject<T, TElement, TEntityObject>(
            this IRuleBuilder<T, TElement> ruleBuilder,
        Func<TElement, Result<TEntityObject>> factoryMethod)
        {
            return (IRuleBuilderOptions<T, TElement>)ruleBuilder.Custom((value, context) =>
            {
                Result<TEntityObject> result = factoryMethod(value);

                if (result.IsSuccess)
                    return;

                context.AddFailure(result.Error.Serialize());
            });
        }

        public static IRuleBuilderOptions<T, TProperty> NotEmptyWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithError(Errors.General.ValueIsRequired());
        }

        public static IRuleBuilderOptions<T, string> MaximumLengthWithError<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int maxLength)
        {
            return ruleBuilder
                .MaximumLength(maxLength)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty> GreaterThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty?> GreaterThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }

        public static IRuleBuilderOptions<T, TProperty> LessThanWithError<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .LessThan(valueToCompare)
                .WithError(Errors.General.InvalidLength());
        }
       
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, Error error)
        {
            return rule
                .WithMessage(error.Serialize());
        }
    }
}
