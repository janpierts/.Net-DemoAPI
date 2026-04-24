
using System.Net.Http.Json;
using Demo.Application.Common;
using Demo.Application.demo.ports.Out;

namespace Demo.Infrastructure.ExternalServices;
public class DiscountApiClient : IDiscount, IScopedDependency
{
    private readonly HttpClient _httpClient;

    public DiscountApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetDiscountAsync(int productId)
    {
        var response = await _httpClient.GetFromJsonAsync<DiscountResponse>($"/api/v1/test/Products/{productId}");
        
        return response?.Discount ?? 0;
    }
}

public class DiscountResponse { public int Discount { get; set; } }