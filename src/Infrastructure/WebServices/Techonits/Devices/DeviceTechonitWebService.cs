using RestSharp;

namespace TechOnIt.Infrastructure.WebServices.Techonits.Devices;

internal class DeviceTechonitWebService : IDeviceTechonitWebService
{
    public async Task<List<Device>> GetDevicesAsync(string token, CancellationToken stoppingToken)
    {
        var options = new RestClientOptions("http://192.168.1.82")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/v1/device/getAll", Method.Get);
        request.AddHeader("Authorization", $"Bearer {token}");
        RestResponse response = await client.ExecuteAsync(request);
        List<Device>? devices = new();
        if (response.IsSuccessful)
        {
            var result = JsonSerializer.Deserialize<BaseTechonitResponse<List<Device>>>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            devices = result.Data;
        }
        return devices;
    }
}