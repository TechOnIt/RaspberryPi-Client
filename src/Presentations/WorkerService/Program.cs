namespace TechOnIt.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(async (hostContext, services) =>
            {
                services.AddBoardManagerServices(hostContext.Configuration);
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}