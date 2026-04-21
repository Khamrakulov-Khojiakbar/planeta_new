namespace Planeta.Domain.Entities;

public class PhoneOptions
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public string Unit { get; set; } = string.Empty;

    public int BatteryHealth { get; set; } = 100;
    public int BatteryCapacity { get; set; }
    
}