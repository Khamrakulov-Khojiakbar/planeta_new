namespace Planeta.Application.DTOs.Orders;

public record CreateOrderRequest
(
    string CustomerName,
    string PhoneNumber,
    string Comment,
    List<CartItemDto> Items
    );