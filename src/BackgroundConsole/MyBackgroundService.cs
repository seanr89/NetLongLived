using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class MyBackgroundService : IHostedService, IDisposable
{

    private readonly ILogger _logger;
    private Timer _timer;
    
    internal readonly string _host;

    public MyBackgroundService(ILogger<MyBackgroundService> logger)
    {
        _host = Environment.GetEnvironmentVariable("host") ?? "localhost";
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    #region private

    private void DoWork(object state)
    {
        _logger.LogInformation("Service is running.");
    }

    #endregion
}
