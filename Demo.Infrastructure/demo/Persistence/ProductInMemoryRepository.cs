using Demo.Application.Common;
using Demo.Application.demo.Features.Catalog.Commands;
using Demo.Application.demo.ports.Out;
using Demo.Domain.Demo.model;

namespace Demo.Infrastructure.demo.Persistence;

public class ProductInMemoryRepository : IProductRepository, IScopedDependency
{
    private readonly IProductStatusCache _statusCache;
    private readonly IDiscount _discountService;
    private static readonly List<BEProductEntity> _products = new();

    public ProductInMemoryRepository(IProductStatusCache statusCache, IDiscount discountService)
    {
        _statusCache = statusCache;
        _discountService = discountService;
    }
    public Task<BEProductEntity> Create(CreateUpdateProductCommand entity)
    {
        var newProduct = BEProductEntity.Create(
            _products.Count > 0 ? _products.Max(p => p.ProductId) + 1 : 1,
            entity.Name!,
            entity.Status!.Value,
            entity.Stock!.Value,
            entity.Description!,
            entity.Price!.Value
        );

        _products.Add(newProduct);
        return Task.FromResult(newProduct);
    }

    public Task<BEProductEntity> Update(int id, CreateUpdateProductCommand entity)
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
    
    public async Task<ReadProductModel> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            throw new Exception("Producto no encontrado.");

        var discount = await _discountService.GetDiscountAsync(id);

        var readModel = new ReadProductModel(
            product.ProductId,
            product.Name,
            _statusCache.GetStatusName(product.Status),
            product.Stock,
            product.Description,
            product.Price,
            discount,
            product.Price * (100 - discount)/100,
            product.CreatedAt,
            product.UpdatedAt
        );

        return await Task.FromResult(readModel);
    }
}