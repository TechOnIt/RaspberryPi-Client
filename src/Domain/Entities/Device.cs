namespace TechOnIt.Domain.Entities;

public class Device
{
    Device() { }

    public string Id { get; private set; } = Guid.Empty.ToString();
    public int Pin { get; private set; }
    public bool IsHigh { get; set; } = false;
}