namespace TechOnIt.WorkerService;

public class Worker : BackgroundService
{
    #region DI
    private readonly ILogger<Worker> _logger;
    private readonly IBoardManager _boardManager;
    public Worker(ILogger<Worker> logger,
        IBoardManager boardManager)
    {
        _logger = logger;
        _boardManager = boardManager;
    }
    #endregion

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var boardManager = _boardManager
                .WithIdentity(apiKey: "Ba94QfKlm9k1vR3u", password: "123456");
        while (!stoppingToken.IsCancellationRequested)
        {
            await boardManager.StartNowAsync(stoppingToken);

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);
        }
    }
}