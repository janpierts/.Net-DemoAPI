namespace Demo.Application.demo.ports.Out;
public interface IDiscount
{
    Task<int> GetDiscountAsync(int productId);
}