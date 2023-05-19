using RestSharp;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices.RequestModel;

namespace TechOnIt.Infrastructure.WebServices.Techonits.Authentications;

internal class AuthTechonitWebService : IAuthTechonitWebService
{
    private readonly ILogger<AuthTechonitWebService> _logger;
    public AuthTechonitWebService(ILogger<AuthTechonitWebService> logger)
    {
        _logger = logger;
    }

    public async Task<StructureAccessToken?> GetAccessTokenAsync(string apiKey, string password, CancellationToken stoppingToken = default)
    {

        var options = new RestClientOptions("https://core.techonit.org")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/v1/auth/signin", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        var body = new GetAccessTokenParameter(apiKey, password);
        request.AddStringBody(JsonSerializer.Serialize(body), DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        StructureAccessToken? structureAccessToken = new();
        if (response.IsSuccessful)
        {
            structureAccessToken = JsonSerializer.Deserialize<StructureAccessToken>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        else
            _logger.LogError("auth/signin is failed.");
        return structureAccessToken;
    }
}