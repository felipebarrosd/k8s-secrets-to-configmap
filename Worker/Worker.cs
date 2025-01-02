using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Acessa a configuração 'ConnectionString:db.con'
        var dbConnection = _configuration["ConnectionString:DB.Con"];

        _logger.LogInformation("Worker iniciado. DB Connection String: {dbConnection}", dbConnection);

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker rodando em: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}

