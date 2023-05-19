namespace TechOnIt.Application.Services;

public interface IBoardManager
{
    public string Name { get; }
    public string InstanceId { get; }
    public string ApiKey { get; }
    public string Password { get; }
    public Task<BoardManager> StartNowAsync(CancellationToken stoppingToken = default);
    public BoardManager WithIdentity(string apiKey, string password);
}