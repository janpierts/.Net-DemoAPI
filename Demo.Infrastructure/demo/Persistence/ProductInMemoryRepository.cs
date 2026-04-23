using Demo.Application.Common;
using Demo.Application.demo.Features.Catalog.Commands;
using Demo.Application.demo.ports.Out;
using Demo.Domain.Demo.model;

namespace Demo.Infrastructure.demo.Persistence;

public class ProductInMemoryRepository : IProductRepository, IScopedDependency
{
    private static readonly List<BEProductEntity> _products = new();


    public Task<BEProductEntity> Create(CreateUpdateProductCommand entity)
    {
        var newProduct = BEProductEntity.Create(
            Guid.NewGuid(),
            entity.Name!,
            entity.Status!.Value,
            entity.Stock!.Value,
            entity.Description!,
            entity.Price!.Value
        );

        _products.Add(newProduct);
        return Task.FromResult(newProduct);
    }

    public Task<BEProductEntity> Update(Guid id, CreateUpdateProductCommand entity)
    {
        var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
        if (existingProduct == null)
            throw new Exception("Producto no encontrado.");

        var upProduct = BEProductEntity.Update(
            id,
            entity.Name ?? existingProduct.Name,
            entity.Status ?? existingProduct.Status,
            entity.Stock ?? existingProduct.Stock,
            entity.Description ?? existingProduct.Description,
            entity.Price ?? existingProduct.Price,
            existingProduct.CreatedAt
        );
        var index = _products.IndexOf(existingProduct);
        _products[index] = upProduct;

        return Task.FromResult(upProduct);
    }
    
    public Task<ReadProductModel> GetById(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            throw new Exception("Producto no encontrado.");

        var readModel = new ReadProductModel(
            product.ProductId,
            product.Name,
            product.Status == 1 ? "Activo" : "Inactivo",
            product.Stock,
            product.Description,
            product.Price,
            0, // Asumiendo que no hay descuento en este ejemplo
            product.Price, // Sin descuento aplicado
            product.CreatedAt,
            product.UpdatedAt
        );

        return Task.FromResult(readModel);
    }
}