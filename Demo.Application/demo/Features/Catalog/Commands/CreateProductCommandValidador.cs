
using FluentValidation;
using Demo.Application.demo.Common.Validation;

namespace Demo.Application.demo.Features.Catalog.Commands;

public class CreateProductCommandValidador : AbstractValidator<CreateUpdateProductCommand>
{
    public CreateProductCommandValidador()
    {
        RuleFor(x => x.Name)
            .Must(x => !string.IsNullOrEmpty(x)).WithMessage("El nombre es obligatorio.")
            .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.")
            .MustHaveLettersIfDigits().WithMessage("El nombre no puede ser solo un numero");
        RuleFor(x => x.Status)
            .NotNull().WithMessage("El estado es obligatorio.")
            .InclusiveBetween(0, 1).WithMessage("El estado debe ser 0 o 1.");
        RuleFor(x => x.Stock)
            .NotEmpty().WithMessage("El stock es obligatorio.")
            .MustBeZeroOrPositive().WithMessage("El stock debe ser cero o positivo.");
        RuleFor(x => x.Description)
            .Must(x => !string.IsNullOrEmpty(x)).WithMessage("La descripción es obligatoria.")
            .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
        RuleFor(x => x.Price)
            .NotNull().WithMessage("El precio es obligatorio.")
            .MustBeZeroOrPositive().WithMessage("El precio debe ser cero o positivo.");
    }
}