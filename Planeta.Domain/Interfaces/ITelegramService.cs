using Planeta.Domain.Entities;

namespace Planeta.Domain.Interfaces;

public interface ITelegramService
{
    Task SendOrderNotificationAsync(Order order);
}