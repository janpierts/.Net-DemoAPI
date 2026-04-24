using Demo.Domain.Demo.model;
using Demo.Application.demo.Features.Catalog.Commands;

namespace Demo.Application.demo.ports.Out;
public interface IProductRepository
{
    Task<BEProductEntity> Create(CreateUpdateProductCommand entity);
    Task<BEProductEntity> Update(int id, CreateUpdateProductCommand entity);
    Task<ReadProductModel> GetById(int id);
}