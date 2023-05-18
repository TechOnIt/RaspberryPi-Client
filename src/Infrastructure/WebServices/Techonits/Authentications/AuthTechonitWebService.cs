namespace TechOnIt.Infrastructure.WebServices.Techonits.Authentications;

public class AuthTechonitWebService : IAuthTechonitWebService
{
    public async Task GetAccessTokenAsync(string apiKey, string password, CancellationToken stoppingToken)
    {
        await Console.Out.WriteLineAsync("Request for token.");
    }
}