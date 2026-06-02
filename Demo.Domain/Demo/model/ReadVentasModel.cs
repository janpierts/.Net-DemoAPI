namespace Demo.Domain.Demo.model;

public record ReadVentasModel(
    int VentasId,
    string Cliente,
    string Producto,
    string Categoria,
    decimal Price,
    int Cantidad,
    DateTime CreatedAt
);
