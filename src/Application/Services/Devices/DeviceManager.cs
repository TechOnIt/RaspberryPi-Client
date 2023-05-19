namespace TechOnIt.Application.Services.Devices;

internal class DeviceManager : IDeviceManager
{
    public List<Device> Devices { get; private set; }

    public DeviceManager()
    {
        Devices = new List<Device>();
    }
}
