
namespace Demo.Application.demo.Features.Catalog.Commands;

public record CreateUpdateProductCommand(
    string? Name,
    int? Status,
    int? Stock,
    string? Description,
    decimal? Price 
);

/*
using System.ComponentModel.DataAnnotations;

namespace Demo.Application.demo.Features.Catalog.Commands;

public record UpdateProductCommand(
    [Required(ErrorMessage = "El ID del producto es obligatorio")]
    Guid ProductId,

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    string Name,

    [Range(0, 10, ErrorMessage = "Status inválido")] // Asumiendo que tu status es un enum o rango
    int Status,

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    int Stock,

    [StringLength(500, ErrorMessage = "La descripción es muy larga")]
    string Description,

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    decimal Price
);

using FluentValidation;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        // NotEmpty() es el "Not Blank" definitivo
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio y no puede estar en blanco")
            .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("La descripción es obligatoria")
            .MaximumLength(500).WithMessage("La descripción es muy larga");

        RuleFor(x => x.Status)
            .InclusiveBetween(0, 10).WithMessage("Status inválido");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");


        RuleFor(x => x.OptionalDescription)
    .NotEmpty().WithMessage("Si envías una descripción, no puede estar vacía o solo contener espacios.")
    .MaximumLength(500).WithMessage("La descripción es demasiado larga.")
    .When(x => x.OptionalDescription != null); // Solo valida si el campo NO es nulo
    }
}

[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
{
    // 1. Instancias el validador (o lo inyectas)
    var validator = new CreateProductCommandValidator();
    
    // 2. Validar
    var result = await validator.ValidateAsync(command);
    
    // 3. Si falla, devuelves el error inmediatamente
    if (!result.IsValid) 
    {
        return BadRequest(result.Errors); // Aquí devuelve los mensajes definidos en .WithMessage()
    }

    // 4. Si es válido, prosigues al servicio...
    return Ok(await _productService.CreateAsync(command));
}


public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        // ... el resto de reglas estrictas
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        // El nombre es opcional en el update (si viene, debe ser válido)
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Name));

        // El stock es obligatorio, pero solo si el usuario decide enviarlo
        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Stock != null); 
            
        // ... otras reglas
    }
}

// Extensión para reglas comunes
public static class ProductValidationExtensions
{
    public static IRuleBuilderOptions<T, decimal> MustHaveValidPrice<T>(this IRuleBuilder<T, decimal> ruleBuilder)
    {
        return ruleBuilder.GreaterThan(0).WithMessage("El precio debe ser mayor a 0");
    }
}

// Y en tus validadores simplemente haces:
RuleFor(x => x.Price).MustHaveValidPrice();




using System.ComponentModel.DataAnnotations;

namespace Demo.Application.demo.Features.Catalog.Commands;

public record UpdateProductCommand(
    [Required(ErrorMessage = "El ID del producto es obligatorio")]
    Guid ProductId,

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    string Name,

    [Range(0, 10, ErrorMessage = "Status inválido")] // Asumiendo que tu status es un enum o rango
    int Status,

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    int Stock,

    [StringLength(500, ErrorMessage = "La descripción es muy larga")]
    string Description,

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    decimal Price
);
*/