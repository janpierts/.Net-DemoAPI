using FluentValidation;

namespace Demo.Application.demo.Common.Validation;

public static class ProductValidation
{
    public static IRuleBuilderOptions<T, decimal?> MustBeZeroOrPositive<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
    {
        return ruleBuilder.Must(value => !value.HasValue || value.Value >= 0).WithMessage("El valor debe ser cero o positivo.");
    }
    public static IRuleBuilderOptions<T, int?> MustBeZeroOrPositive<T>(this IRuleBuilder<T, int?> ruleBuilder)
    {
        return ruleBuilder.Must(value => !value.HasValue || value.Value >= 0).WithMessage("El valor debe ser cero o positivo.");
    }
}