using Demo.Domain.Demo.model;
using Demo.Application.demo.Features.Catalog.Commands;

namespace Demo.Application.demo.ports.Out;
public interface IProductRepository
{
    Task<BEProductEntity> CreateAsync(CreateUpdateProductCommand entity);
    Task<BEProductEntity> UpdateAsync(int id, CreateUpdateProductCommand entity);
    Task<ReadProductModel> GetByIdAsync(int id);
    Task<IEnumerable<ReadVentasModel>> GetVentasAsync();
    Task<bool> CreateVentaAsync(Demo.Application.demo.Features.Catalog.Commands.CreateUpdateVentasCommand command);
}