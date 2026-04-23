namespace Demo.Domain.Demo.model;

public class BEProductEntity
{
    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public int Status { get; private set; }
    public int Stock { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected BEProductEntity() { }

    public BEProductEntity(Guid productId, string name, int status, int stock, string description, decimal price, DateTime createdAt, DateTime updatedAt)
    {
        ProductId = productId;
        Name = name;
        Status = status;
        Stock = stock;
        Description = description;
        Price = price;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static BEProductEntity Create(Guid productId, string name, int status, int stock, string description, decimal price)
    {
        Validate(name, status, stock, description, price);
        
        return new BEProductEntity(productId, name, status, stock, description, price, DateTime.UtcNow, DateTime.UtcNow);
    }

    public static BEProductEntity Update(Guid productId, string name, int status, int stock, string description, decimal price, DateTime createdAt)
    {
        Validate(name, status, stock, description, price);

        return new BEProductEntity(productId, name, status, stock, description, price, createdAt, DateTime.UtcNow);

    }
    private static void Validate(string name, int status, int stock, string description, decimal price)
    {
        if (price < 0) throw new ArgumentException("El precio no puede ser menor a cero.");
        if (stock < 0) throw new ArgumentException("El stock no puede ser menor a cero.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("La descripción es obligatoria.");
        if (status < 0 || status > 1) throw new ArgumentException("El estado no puede ser menor a cero o mayor a uno.");
    }
}
