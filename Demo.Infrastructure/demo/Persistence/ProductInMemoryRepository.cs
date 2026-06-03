using Demo.Application.Common;
using Demo.Application.demo.Features.Catalog.Commands;
using Demo.Application.demo.ports.Out;
using Demo.Domain.Demo.model;
using Demo.Infrastructure.demo.Adapters;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo.Infrastructure.demo.Persistence;

public class ProductInMemoryRepository : IProductRepository, IScopedDependency
{
    private readonly IProductStatusCache _statusCache;
    private readonly IDiscount _discountService;
    private readonly IVentasAdapter _ventasAdapter;
    private readonly string _connectionString;
    private readonly string _getVentasSpName;
    private readonly string _postVentasSpName;
    private static readonly List<BEProductEntity> _products = new();

    public ProductInMemoryRepository(IProductStatusCache statusCache, IDiscount discountService, IConfiguration configuration, IVentasAdapter ventasAdapter)
    {
        _statusCache = statusCache;
        _discountService = discountService;
        _ventasAdapter = ventasAdapter;
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? configuration["ConnectionStrings:DefaultConnection"] ?? string.Empty;
        _getVentasSpName = configuration["StoredProcedures:GetVentas"] ?? "sp_GetVentas";
        _postVentasSpName = configuration["StoredProceduresPost:PostVentas"] ?? "sp_PostVentas";
    }

    public async Task<bool> CreateVentaAsync(Demo.Application.demo.Features.Catalog.Commands.CreateUpdateVentasCommand command)
    {
        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        using var cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = _postVentasSpName;

        cmd.Parameters.Add(new SqlParameter("@ClienteId", SqlDbType.Int) { Value = command.Cliente ?? (object)DBNull.Value });
        cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = command.Producto ?? (object)DBNull.Value });
        cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int) { Value = command.Cantidad ?? (object)DBNull.Value });

        var rows = await cmd.ExecuteNonQueryAsync();
        return rows > 0;
    }
    public Task<BEProductEntity> CreateAsync(CreateUpdateProductCommand entity)
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

    public Task<BEProductEntity> UpdateAsync(int id, CreateUpdateProductCommand entity)
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
    
    public async Task<ReadProductModel> GetByIdAsync(int id)
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

    public async Task<IEnumerable<ReadVentasModel>> GetVentasAsync()
    {
        var results = new List<ReadVentasModel>();
        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        using var cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = _getVentasSpName;

        using var reader = await cmd.ExecuteReaderAsync();
        var ventas = _ventasAdapter.Map(reader);
        results.AddRange(ventas);

        return await Task.FromResult(results.AsEnumerable());
    }
}