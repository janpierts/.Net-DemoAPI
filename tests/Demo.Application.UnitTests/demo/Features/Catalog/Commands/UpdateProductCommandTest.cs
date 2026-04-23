using Demo.Application.demo.Features.Catalog.Commands;
using FluentValidation.TestHelper;
using Xunit;

namespace Demo.Application.UnitTests.demo.Features.Catalog.Commands;

public class UpdateProductCommandTest
{
    private readonly UpdateProductCommandValidador _validator = new ();
    
    [Fact]
    public void Should_Be_Valid_When_All_Fields_Are_Null()
    {
        // Escenario: El usuario no quiere actualizar nada (o solo el ID).
        // Si todo es null, FluentValidation no debe disparar errores.
        var command = new CreateUpdateProductCommand(null, null, null, null, null);

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty_But_Provided()
    {
        // Escenario: El usuario decidió enviar el nombre, pero envió una cadena vacía.
        var command = new CreateUpdateProductCommand("", null, null, null, null);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Name)
              .WithErrorMessage("El nombre es obligatorio.");
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Only_Digits_And_Provided()
    {
        var command = new CreateUpdateProductCommand("12345", null, null, null, null);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Status_Is_Out_Of_Range_And_Provided()
    {
        var command = new CreateUpdateProductCommand(null, 5, null, null, null);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Status);
    }

    [Fact]
    public void Should_Have_Error_When_Stock_Is_Negative_And_Provided()
    {
        var command = new CreateUpdateProductCommand(null, null, -10, null, null);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Stock);
    }

    [Fact]
    public void Should_Have_Error_When_Price_Is_Negative_And_Provided()
    {
        var command = new CreateUpdateProductCommand(null, null, null, null, -50.0m);

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Price);
    }

    [Fact]
    public void Should_Be_Valid_When_Only_Partial_Fields_Are_Provided()
    {
        // Escenario: Solo actualizamos el nombre y el precio, el resto queda igual (null).
        var command = new CreateUpdateProductCommand("Nuevo Nombre", null, null, null, 99.99m);

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
