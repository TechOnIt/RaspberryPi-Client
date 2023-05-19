using RestSharp;

namespace TechOnIt.Infrastructure.WebServices.Techonits.Devices;

internal class DeviceTechonitWebService : IDeviceTechonitWebService
{
    public async Task<List<Device>> GetDevicesAsync(CancellationToken stoppingToken)
    {
        var options = new RestClientOptions("https://localhost:7059")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/v1/device/getAll", Method.Get);
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik15IFN0cnVjdHVyZSIsIm5hbWVpZCI6IjA0ZTMxYjM0LTExNDAtNDgzOC1iOTdmLWVjY2VhNDVjNTBjNiIsImNlcnRzZXJpYWxudW1iZXIiOiJCYTk0UWZLbG05azF2UjN1IiwibmJmIjoxNjg0NDg2MDc2LCJleHAiOjE2ODQ0ODgxNzYsImlhdCI6MTY4NDQ4NjA3NiwiaXNzIjoiVGVjaE9uSXQiLCJhdWQiOiJJT1QifQ.I_lX-8LN-pLT3EmartkdRi1r7Y-fwu-Epshum7JFnY8");
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