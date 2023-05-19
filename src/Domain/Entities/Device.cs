namespace TechOnIt.Domain.Entities;

public class Device
{
    public string Id { get; set; } = Guid.Empty.ToString();
    public int Pin { get; set; }
    public bool IsHigh { get; set; } = false;
}