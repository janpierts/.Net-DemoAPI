using Demo.Domain.Demo.model;
using Demo.Application.Common;

namespace Demo.Application.demo.ports.In;

public interface IProductService
{
    Task<ServiceResult<BEProductEntity>> Create(BEProductEntity entity);
    Task<ServiceResult<BEProductEntity>> Update(Guid id, BEProductEntity entity);
    Task<ReadProductModel> GetById(Guid id);
}