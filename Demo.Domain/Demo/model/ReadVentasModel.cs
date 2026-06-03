namespace Demo.Domain.Demo.model;

public record ReadVentasModel(
    int VentaId,
    string Cliente,
    string Producto,
    DateTime Fecha,
    int Cantidad
);
