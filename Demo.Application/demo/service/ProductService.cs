using Demo.Application.demo.ports.In;
using Demo.Application.demo.ports.Out;
using Demo.Domain.Demo.model;
using Demo.Application.Common;
using Demo.Application.demo.Features.Catalog.Commands;

namespace Demo.Application.demo.service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ServiceResult<BEProductEntity>> Create(CreateUpdateProductCommand entity)
    {
        try
        {
            var createdProduct = await _productRepository.Create(entity);
            return ServiceResult<BEProductEntity>.Ok(createdProduct, "Producto creado exitosamente.");
        }
        catch (Exception ex)
        {
            return ServiceResult<BEProductEntity>.Failure("Error al crear el producto.", new List<string> { ex.Message });
        }
    }
    public async Task<ServiceResult<BEProductEntity>> Update(Guid id, CreateUpdateProductCommand entity)
    {
        try
        {
            var updatedProduct = await _productRepository.Update(id, entity);
            return ServiceResult<BEProductEntity>.Ok(updatedProduct, "Producto actualizado exitosamente.");
        }
        catch (Exception ex)
        {
            return ServiceResult<BEProductEntity>.Failure("Error al actualizar el producto.", new List<string> { ex.Message });
        }
    }
    public async Task<ReadProductModel> GetById(Guid id)
    {
        return await _productRepository.GetById(id);
    }
}