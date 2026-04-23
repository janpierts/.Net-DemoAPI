using Demo.Domain.Demo.model;
using Demo.Application.Common;
using Demo.Application.demo.Features.Catalog.Commands;

namespace Demo.Application.demo.ports.In;

public interface IProductService
{
    Task<ServiceResult<BEProductEntity>> Create(CreateUpdateProductCommand entity);
    Task<ServiceResult<BEProductEntity>> Update(Guid id, CreateUpdateProductCommand entity);
    Task<ReadProductModel> GetById(Guid id);
}