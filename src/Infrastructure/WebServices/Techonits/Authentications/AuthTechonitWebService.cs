using RestSharp;
using TechOnIt.Infrastructure.Services.Caches;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices.RequestModel;

namespace TechOnIt.Infrastructure.WebServices.Techonits.Authentications;

internal class AuthTechonitWebService : IAuthTechonitWebService
{
    private readonly ILogger<AuthTechonitWebService> _logger;
    private readonly ICacheManager _cacheManager;
    public AuthTechonitWebService(ILogger<AuthTechonitWebService> logger,
        ICacheManager cacheManager)
    {
        _logger = logger;
        _cacheManager = cacheManager;
    }

    public async Task<StructureAccessToken?> GetAccessTokenAsync(string apiKey, string password, CancellationToken stoppingToken = default)
    {
        StructureAccessToken? structureAccessToken = _cacheManager.Get<StructureAccessToken>("AccessToken");

        if (structureAccessToken is not null)
            return structureAccessToken;

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
        if (response.IsSuccessful)
        {
            structureAccessToken = JsonSerializer.Deserialize<StructureAccessToken>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if(structureAccessToken is not null)
            {
                bool isCacheStoreSucceded = _cacheManager.Set("AccessToken", structureAccessToken, DateTimeOffset.Now.AddMinutes(20));
                if(isCacheStoreSucceded == false)
                    _logger.LogWarning("Cache store on AccessToken failed.");
            }
        }
        else
            _logger.LogError("auth/signin is failed.");
        return structureAccessToken;
    }
}