namespace Planeta.Application.DTOs.PhoneOptions;

public record PhoneOptionsDto
(
    int Id,
    int Capacity,
     string Unit,
    int BatteryHealth,
    int BatteryCapacity
        );