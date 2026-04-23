
using FluentValidation;
using Demo.Application.demo.Common.Validation;

namespace Demo.Application.demo.Features.Catalog.Commands;

public class UpdateProductCommandValidador : AbstractValidator<CreateUpdateProductCommand>
{
    public UpdateProductCommandValidador()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.")
            .MustHaveLettersIfDigits().WithMessage("El nombre no puede ser solo un numero")
            .When(x => x.Name != null);
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("El estado es obligatorio.")
            .InclusiveBetween(0, 1).WithMessage("El estado debe ser 0 o 1.")
            .When(x => x.Status.HasValue);
        RuleFor(x => x.Stock)
            .NotEmpty().WithMessage("El stock es obligatorio.")
            .MustBeZeroOrPositive().WithMessage("El stock debe ser cero o positivo.")
            .When(x => x.Stock.HasValue);
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.")
            .When(x => x.Description != null);
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("El precio es obligatorio.")
            .MustBeZeroOrPositive().WithMessage("El precio debe ser cero o positivo.")
            .When(x => x.Price.HasValue);
    }
}