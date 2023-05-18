namespace TechOnIt.Infrastructure.WebServices.Techonits.Authentications
{
    public interface IAuthTechonitWebService
    {
        /// <summary>
        /// Get jwt token and refresh token for structure.
        /// </summary>
        /// <param name="apiKey">structure api key from desk dashboard.</param>
        /// <param name="password">structure password from desk dashboard.</param>
        public Task GetAccessTokenAsync(string apiKey, string password, CancellationToken cancellationToken);
    }
}
