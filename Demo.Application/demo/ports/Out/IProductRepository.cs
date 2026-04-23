using Demo.Domain.Demo.model;

namespace Demo.Application.demo.ports.Out;
public interface IProductRepository
{
    Task<BEProductEntity> Create(BEProductEntity entity);
    Task<BEProductEntity> Update(Guid id, BEProductEntity entity);
    Task<ReadProductModel> GetById(Guid id);
}