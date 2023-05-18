using TechOnIt.Infrastructure.WebServices.Techonits;

namespace TechOnIt.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(async (hostContext, services) =>
            {
                services.AddCacheService(hostContext.Configuration);
                services.AddTechonitService();
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}