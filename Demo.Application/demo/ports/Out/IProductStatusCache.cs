namespace Demo.Application.demo.ports.Out;

public interface IProductStatusCache
{
    string GetStatusName(int key);
}