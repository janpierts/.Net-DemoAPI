namespace Demo.Domain.Demo.model;

public record ReadProductModel(
    int ProductId,
    string Name,
    string StatusName,
    int Stock,
    string Description,
    decimal Price,
    decimal Discount,
    decimal FinalPrice,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
