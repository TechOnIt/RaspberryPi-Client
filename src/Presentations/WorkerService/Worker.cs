using TechOnIt.Infrastructure.WebServices.Techonits;

namespace TechOnIt.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITechonitWebService _techonitWebService;

        public Worker(ILogger<Worker> logger,
            ITechonitWebService techonitWebService)
        {
            _logger = logger;
            _techonitWebService = techonitWebService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _techonitWebService.Auth.GetAccessTokenAsync("Ba94QfKlm9k1vR3u", "123456", stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}