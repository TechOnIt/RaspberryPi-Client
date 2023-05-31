using Microsoft.Extensions.Logging;
using System.Device.Gpio;
using TechOnIt.Infrastructure.WebServices.Techonits;

namespace TechOnIt.Application.Services;

public class BoardManager : IBoardManager
{
    public string Name { get; private set; } = string.Empty;
    public string InstanceId { get; private set; } = Guid.NewGuid().ToString();
    public string ApiKey { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    private readonly ILogger<BoardManager> _logger;
    private readonly ITechonitWebService _techonitWebService;
    public BoardManager(ITechonitWebService techonitWebService,
        ILogger<BoardManager> logger)
    {
        _techonitWebService = techonitWebService;
        _logger = logger;
    }

    public async Task<BoardManager> StartNowAsync(CancellationToken stoppingToken = default)
    {
        // Get access token from api.
        var accessToken = await _techonitWebService.Auth.GetAccessTokenAsync(ApiKey, Password, stoppingToken);
        if (accessToken != null)
            _logger.LogDebug(accessToken.Token);
        if (accessToken is null)
            return this;
        // Get All devicesfrom api.
        var devices = await _techonitWebService.Device.GetDevicesAsync(accessToken.Token,stoppingToken);
        _logger.LogInformation($"{devices.Count} devices founded.");
        foreach (var device in devices)
        {
            //GpioController controller = new GpioController();
            //if (!controller.IsPinOpen(device.Pin) || controller.GetPinMode(device.Pin) != PinMode.Output)
            //    controller.OpenPin(device.Pin, PinMode.Output);
            _logger.LogInformation($"#{device.Pin} is {(device.IsHigh ? "High" : "Low")}");
            //controller.Write(device.Pin, device.IsHigh ? PinValue.High : PinValue.Low);
        }
        return this;
    }

    public BoardManager WithIdentity(string apiKey, string password)
    {
        ApiKey = apiKey;
        Password = password;
        return this;
    }
}