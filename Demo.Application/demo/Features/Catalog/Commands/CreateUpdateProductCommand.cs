
namespace Demo.Application.demo.Features.Catalog.Commands;

public record CreateUpdateProductCommand(
    string? Name,
    int? Status,
    int? Stock,
    string? Description,
    decimal? Price 
);