using Demo.Application.demo.Features.Catalog.Commands; // <--- Esto es vital
using FluentValidation.TestHelper;
using Xunit;
namespace Demo.Application.UnitTests.demo.Features.Catalog.Commands;

public class CreateProductCommandTests
{
    private readonly CreateProductCommandValidador _validator = new ();
    
    [Fact]
    public void TestName_is_Empty()
    {
        var command = new CreateUpdateProductCommand(Name: "", Status: 1, Stock: 10, Description: "Test", Price: 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void TestStock_is_Empty()
    {
        var command = new CreateUpdateProductCommand(Name: "name", Stock: null, Status: 1, Description: "Test", Price: 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Stock);
    }

    [Fact]
    public void TestName_is_Too_Long()
    {
        // 201 caracteres
        var command = new CreateUpdateProductCommand(new string('a', 201), 1, 10, "Desc", 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void TestName_is_Only_Digits()
    {
        // Regla: MustHaveLettersIfDigits
        var command = new CreateUpdateProductCommand("12345", 1, 10, "Desc", 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void TestStatus_is_Invalid_Range()
    {
        // Rango permitido: 0 o 1
        var command = new CreateUpdateProductCommand("Name", 5, 10, "Desc", 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Status);
    }

    [Fact]
    public void TestStock_is_Negative()
    {
        var command = new CreateUpdateProductCommand("Name", 1, -5, "Desc", 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Stock);
    }

    [Fact]
    public void TestDescription_is_Too_Long()
    {
        // 501 caracteres
        var command = new CreateUpdateProductCommand("Name", 1, 10, new string('a', 501), 10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Description);
    }

    [Fact]
    public void TestPrice_is_Negative()
    {
        var command = new CreateUpdateProductCommand("Name", 1, 10, "Desc", -10.0m);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Price);
    }

    [Fact]
    public void TestCommand_Is_Valid()
    {
        var command = new CreateUpdateProductCommand("Producto Valido 1", 1, 10, "Descripcion valida", 10.0m);        
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}