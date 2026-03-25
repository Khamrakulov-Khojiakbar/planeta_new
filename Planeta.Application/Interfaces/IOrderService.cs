using Planeta.Application.DTOs.Orders;

namespace Planeta.Application.Interfaces;

public interface IOrderService
{
    Task<int> CreateOrderAsync(CreateOrderRequest request);
}