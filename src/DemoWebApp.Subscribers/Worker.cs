using NATS.Client;

namespace DemoWebApp.Subscribers;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConnection _natsConnection;

    public Worker(ILogger<Worker> logger, IConnection natsConnection)
    {
        _logger = logger;
        _natsConnection = natsConnection;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var testSub = _natsConnection.SubscribeAsync(
            "blah",
            "blah.queue",
            (_, args) =>
            {
                _logger.LogInformation($"Called Subject: {args.Message.Subject}");
            }
        );

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
        if (stoppingToken.IsCancellationRequested)
        {
            await testSub.DrainAsync();
        }
    }
}
