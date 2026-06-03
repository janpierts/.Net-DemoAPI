
namespace Demo.Application.demo.Features.Catalog.Commands;

public record CreateUpdateVentasCommand(
    int? Cliente,
    int? Producto,
    int? Categoria,
    decimal? Precio,
    int? Cantidad 
);